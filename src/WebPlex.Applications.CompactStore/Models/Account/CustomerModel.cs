namespace WebPlex.Applications.CompactStore.Models {
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Configuration;
    using WebPlex.Applications.CompactStore.Properties;

    public class CustomerModel : DbModelBase {
        [Display(Name = "Members_Customer_CellPhone", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [Phone(ErrorMessageResourceName = "Validation_InvalidPhone", ErrorMessageResourceType = typeof (Resources), ErrorMessage = null)]
        [Remote("Account-ValidateCustomerCellPhone", HttpMethod = "Post", AdditionalFields = "Id", ErrorMessage = "", ErrorMessageResourceName = "Validation_Duplicate", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.PhoneNumber)]
        public virtual string CellPhone { get; set; }

        [ReadOnly(true)]
        public virtual string SecuredSalt { get; set; }

        [ReadOnly(true)]
        public virtual string SecuredPassword { get; set; }

        [Display(Name = "Members_Customer_FirstName", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual string FirstName { get; set; }

        [Display(Name = "Members_Customer_LastName", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual string LastName { get; set; }

        [Display(Name = "Members_Customer_Email", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [EmailAddress(ErrorMessageResourceName = "Validation_InvalidEmail", ErrorMessageResourceType = typeof (Resources), ErrorMessage = null)]
        [Remote("Account-ValidateCustomerEmail", HttpMethod = "Post", AdditionalFields = "Id", ErrorMessage = "", ErrorMessageResourceName = "Validation_Duplicate", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }

        [Display(Name = "Members_Customer_Gender", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual CustomerGender Gender { get; set; }

        [Display(Name = "Members_Customer_IsAdmin", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual bool IsAdmin { get; set; }

        [Display(Name = "Members_Customer_InvalidCredentialsAttempt", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual int InvalidCredentialsAttempt { get; set; }

        [Display(Name = "Members_Customer_LockedOutDateUtc", ResourceType = typeof (Resources))]
        public virtual DateTime LockedOutDateUtc { get; set; }

        [Display(Name = "Members_Customer_ResetPasswordToken", ResourceType = typeof (Resources))]
        public virtual string ResetPasswordToken { get; set; }

        [Display(Name = "Members_Customer_ResetPasswordRequestedDateUtc", ResourceType = typeof (Resources))]
        public virtual DateTime? ResetPasswordRequestedDateUtc { get; set; }

        [Display(Name = "Members_Customer_ResetPasswordExpiresDateUtc", ResourceType = typeof (Resources))]
        public virtual DateTime? ResetPasswordExpiresDateUtc {
            get {
                if (ResetPasswordRequestedDateUtc == null)
                    return null;

                return ((DateTime) ResetPasswordRequestedDateUtc).Add(AppConfiguration.Current.CustomerResetPasswordTokenValidityDuration);
            }
        }
    }
}
