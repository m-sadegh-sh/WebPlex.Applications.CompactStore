namespace WebPlex.Applications.CompactStore.Mvc {
    using System;
    using System.Web;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Security;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class CustomerAuthorizedAttribute : AuthorizeAttribute {
        private AuthorizationContext _filterContext;

        public override void OnAuthorization(AuthorizationContext filterContext) {
            _filterContext = filterContext;

            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            var adminRequired = _filterContext.ActionDescriptor.IsDefined(typeof (AdminRequiredAttribute), true) ||
                                _filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof (AdminRequiredAttribute), true);

            return CustomerContext.Current.IsAuthenticated && (!adminRequired || CustomerContext.Current.Customer.IsAdmin);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            var urlHelper = new UrlHelper(filterContext.RequestContext);

            filterContext.Result = new RedirectResult(urlHelper.Action(MVC.Account.Login(filterContext.HttpContext.Request.Url.PathAndQuery)));
        }
    }
}
