namespace WebPlex.Applications.CompactStore.Controllers {
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Configuration;
    using WebPlex.Applications.CompactStore.Data.Repositories;
    using WebPlex.Applications.CompactStore.Extensions;
    using WebPlex.Applications.CompactStore.Mapping;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Mvc;
    using WebPlex.Applications.CompactStore.Properties;
    using WebPlex.Applications.CompactStore.Security;

    public partial class AccountController : StoreController {
        private readonly ICustomerRepository _customerRepository;
        private readonly NotificationController _notificationController;

        public AccountController(ICustomerRepository customerRepository, NotificationController notificationController) {
            _customerRepository = customerRepository;
            _notificationController = notificationController;
        }

        [HttpPost]
        [AntiForgeryTokenValidatable]
        public virtual ActionResult ValidateCustomerCellPhone(string cellPhone, int? id, bool freeness) {
            var customer = _customerRepository.GetByCellPhone(cellPhone);

            var isValid = !customer.IsDuplicate(id, freeness);

            return Json(isValid);
        }

        [HttpPost]
        [AntiForgeryTokenValidatable]
        public virtual ActionResult ValidateCustomerEmail(string email, int? id, bool freeness) {
            var customer = _customerRepository.GetByEmail(email);

            var isValid = !customer.IsDuplicate(id, freeness);

            return Json(isValid);
        }

        [HttpGet]
        public virtual ActionResult Register(string returnUrl) {
            if (CustomerContext.Current.IsAuthenticated)
                return RedirectedAsync(returnUrl, Resources.Error_AlreadyLoggedIn, true);

            var model = new RegisterModel();

            return ViewAsync(Views.Register, Views._Register, model);
        }

        [HttpPost]
        [AntiForgeryTokenValidatable]
        public virtual ActionResult Register(RegisterModel model, string returnUrl) {
            if (CustomerContext.Current.IsAuthenticated)
                return RedirectedAsync(returnUrl, Resources.Error_AlreadyLoggedIn, true);

            if (model == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Customer);

            var dbCustomer = _customerRepository.GetByCellPhone(model.CellPhone);
            if (dbCustomer != null)
                ModelState["CellPhone"].Errors.Add(string.Format(Resources.Validation_Duplicate, Resources.Members_Customer_CellPhone));

            dbCustomer = _customerRepository.GetByEmail(model.Email);
            if (dbCustomer != null)
                ModelState["Email"].Errors.Add(string.Format(Resources.Validation_Duplicate, Resources.Members_Customer_Email));

            if (!ModelState.IsValid)
                return ViewAsync(Views.Register, Views._Register, model);

            dbCustomer = model.ToCustomer();

            SecurityHelpers.UpdateCustomerPassword(dbCustomer, model.Password, false);

            _customerRepository.AddOrUpdate(dbCustomer);
            _customerRepository.SaveChanges();

            CustomerContext.Current.Customer = dbCustomer;

            //_notificationController.Registered(dbCustomer);

            return RedirectedAsync(returnUrl, Resources.Success_Registered);
        }

        [HttpGet]
        public virtual ActionResult Login(string returnUrl) {
            if (CustomerContext.Current.IsAuthenticated)
                return RedirectedAsync(returnUrl, Resources.Error_AlreadyLoggedIn, true);

            var model = new LoginModel();

            return ViewAsync(Views.Login, Views._Login, model);
        }

        [HttpPost]
        [AntiForgeryTokenValidatable]
        public virtual ActionResult Login(LoginModel model, string returnUrl) {
            if (CustomerContext.Current.IsAuthenticated)
                return RedirectedAsync(returnUrl, Resources.Error_AlreadyLoggedIn, true);

            if (model == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Customer);

            if (!ModelState.IsValid)
                return ViewAsync(Views.Login, Views._Login, model);

            var dbCustomer = _customerRepository.GetByCellPhone(model.CellPhoneOrEmail);

            if (dbCustomer == null)
                dbCustomer = _customerRepository.GetByEmail(model.CellPhoneOrEmail);

            if (dbCustomer == null)
                return FailedAsync(Views.Login, Views._Login, model, Resources.Validation_InvalidCredentials);

            if (dbCustomer.IsLockedOut())
                return FailedAsync(Views.Login, Views._Login, model, string.Format(Resources.Validation_CustomerAlreadyLocked, (dbCustomer.LockedOutDateUtc.Add(AppConfiguration.Current.CustomerLockDuration) - DateTime.Now).Minutes));

            if (!SecurityHelpers.ValidatePassword(model.Password, dbCustomer.SecuredPassword, dbCustomer.SecuredSalt)) {
                dbCustomer.InvalidCredentialsAttempt++;
                if (dbCustomer.InvalidCredentialsAttempt >= AppConfiguration.Current.MaximumInvalidCredentialsAttempts) {
                    dbCustomer.InvalidCredentialsAttempt = 0;
                    dbCustomer.LockedOutDateUtc = DateTime.Now;
                }

                _customerRepository.AddOrUpdate(dbCustomer);
                _customerRepository.SaveChanges();

                if (dbCustomer.IsLockedOut())
                    return FailedAsync(Views.Login, Views._Login, model, string.Format(Resources.Validation_CustomerLocked, AppConfiguration.Current.MaximumInvalidCredentialsAttempts, (dbCustomer.LockedOutDateUtc.Add(AppConfiguration.Current.CustomerLockDuration) - DateTime.Now).Minutes));

                return FailedAsync(Views.Login, Views._Login, model, Resources.Validation_InvalidCredentials);
            }

            dbCustomer.InvalidCredentialsAttempt = 0;
            dbCustomer.LockedOutDateUtc = DateTime.Now.Add(-AppConfiguration.Current.CustomerLockDuration);

            _customerRepository.AddOrUpdate(dbCustomer);
            _customerRepository.SaveChanges();

            CustomerContext.Current.Customer = dbCustomer;

            //_notificationController.LoggedIn(dbCustomer);

            return RedirectedAsync(returnUrl, Resources.Success_LoggedIn);
        }

        [HttpGet]
        public virtual ActionResult ResetPassword(string returnUrl) {
            var model = new ResetPasswordModel();

            return ViewAsync(Views.ResetPassword, Views._ResetPassword, model);
        }

        [HttpPost]
        [AntiForgeryTokenValidatable]
        public virtual ActionResult ResetPassword(ResetPasswordModel model, string returnUrl) {
            if (model == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Customer);

            if (!ModelState.IsValid)
                return ViewAsync(Views.ResetPassword, Views._ResetPassword, model);

            var dbCustomer = _customerRepository.GetByCellPhone(model.CellPhoneOrEmail);
            if (dbCustomer == null)
                dbCustomer = _customerRepository.GetByEmail(model.CellPhoneOrEmail);

            if (dbCustomer != null) {
                dbCustomer.ResetPasswordToken = SecurityHelpers.GenerateToken(32);
                dbCustomer.ResetPasswordRequestedDateUtc = DateTime.Now;

                _customerRepository.AddOrUpdate(dbCustomer);
                _customerRepository.SaveChanges();

                _notificationController.PasswordResetRequested(dbCustomer);

                return RedirectedAsync(returnUrl, Resources.Success_ResetPasswordTokenSent);
            }

            return FailedAsync(Views.ResetPassword, Views._ResetPassword, model, Resources.Validation_InvalidEmailOrCellPhone);
        }

        [HttpGet]
        public virtual ActionResult ResetPasswordCallback(string resetPasswordToken, string returnUrl) {
            var dbCustomer = _customerRepository.GetByResetPasswordToken(resetPasswordToken);
            if (dbCustomer == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Customer);

            var model = new ResetPasswordCallbackModel {
                ResetPasswordToken = dbCustomer.ResetPasswordToken
            };

            if (dbCustomer.ResetPasswordExpiresDateUtc < DateTime.Now)
                return RedirectedAsync(returnUrl, Resources.Validation_ResetPasswordExpired, true);

            return ViewAsync(Views.ResetPasswordCallback, Views._ResetPasswordCallback, model);
        }

        [HttpPost]
        [AntiForgeryTokenValidatable]
        public virtual ActionResult ResetPasswordCallback(ResetPasswordCallbackModel model, string returnUrl) {
            if (model == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Customer);

            if (!ModelState.IsValid)
                return ViewAsync(Views.ResetPasswordCallback, Views._ResetPasswordCallback, model);

            var dbCustomer = _customerRepository.GetByResetPasswordToken(model.ResetPasswordToken);
            if (dbCustomer == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Customer);

            if (dbCustomer.ResetPasswordExpiresDateUtc < DateTime.Now)
                return RedirectedAsync(returnUrl, Resources.Validation_ResetPasswordExpired, true);

            SecurityHelpers.UpdateCustomerPassword(dbCustomer, model.NewPassword, true);
            
            _customerRepository.AddOrUpdate(dbCustomer);
            _customerRepository.SaveChanges();

            _notificationController.PasswordReset(dbCustomer);

            return RedirectedAsync(returnUrl, Resources.Success_ResetPasswordTokenSent);
        }

        [HttpGet]
        [CustomerAuthorized]
        public virtual ActionResult UpdateProfile(string returnUrl) {
            var model = CustomerContext.Current.Customer;

            return ViewAsync(Views.UpdateProfile, Views._UpdateProfile, model);
        }

        [HttpPost]
        [CustomerAuthorized]
        [AntiForgeryTokenValidatable]
        public virtual ActionResult UpdateProfile(CustomerModel model, string returnUrl) {
            if (model == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Customer);

            var currentCustomer = CustomerContext.Current.Customer;

            model.SecuredSalt = currentCustomer.SecuredSalt;
            model.SecuredPassword = currentCustomer.SecuredPassword;

            var dbCustomer = _customerRepository.GetByCellPhone(model.CellPhone);
            if (dbCustomer.IsDuplicate(currentCustomer.Id, false))
                ModelState["CellPhone"].Errors.Add(string.Format(Resources.Validation_Duplicate, Resources.Members_Customer_CellPhone));

            dbCustomer = _customerRepository.GetByEmail(model.Email);
            if (dbCustomer.IsDuplicate(currentCustomer.Id, false))
                ModelState["Email"].Errors.Add(string.Format(Resources.Validation_Duplicate, Resources.Members_Customer_Email));

            if (!ModelState.IsValid)
                return ViewAsync(Views.UpdateProfile, Views._UpdateProfile, model);

            model.Id = currentCustomer.Id;

            _customerRepository.AddOrUpdate(model);
            _customerRepository.SaveChanges();

            CustomerContext.Current.Customer = model;

            return RedirectedAsync(returnUrl, Resources.Success_ProfileUpdated);
        }

        [HttpGet]
        [CustomerAuthorized]
        public virtual ActionResult ChangePassword(string returnUrl) {
            var model = new ChangePasswordModel();

            return ViewAsync(Views.ChangePassword, Views._ChangePassword, model);
        }

        [HttpPost]
        [CustomerAuthorized]
        [AntiForgeryTokenValidatable]
        public virtual ActionResult ChangePassword(ChangePasswordModel model, string returnUrl) {
            if (model == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Customer);

            var currentCustomer = CustomerContext.Current.Customer;

            if (!SecurityHelpers.ValidatePassword(model.CurrentPassword, currentCustomer.SecuredPassword, currentCustomer.SecuredSalt))
                ModelState["CurrentPassword"].Errors.Add(Resources.Validation_CurrentPasswordIsWrong);

            if (!ModelState.IsValid)
                return ViewAsync(Views.ChangePassword, Views._ChangePassword);

            currentCustomer.SecuredSalt = SecurityHelpers.GenerateSalt();
            currentCustomer.SecuredPassword = SecurityHelpers.HashPassword(model.NewPassword, currentCustomer.SecuredSalt);

            _customerRepository.AddOrUpdate(currentCustomer);
            _customerRepository.SaveChanges();

            //_notificationController.PasswordChanged(currentCustomer);

            return RedirectedAsync(returnUrl, Resources.Success_PasswordChanged);
        }

        [HttpGet]
        [CustomerAuthorized]
        public virtual ActionResult Logout(string returnUrl) {
            CustomerContext.Current.Customer = null;

            return RedirectedAsync(returnUrl, Resources.Success_LoggedOut);
        }
    }
}
