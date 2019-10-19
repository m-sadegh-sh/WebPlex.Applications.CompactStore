namespace WebPlex.Applications.CompactStore.Mvc {
    using System;
    using System.Web.Helpers;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class AntiForgeryTokenValidatableAttribute : FilterAttribute, IAuthorizationFilter {
        private const string TOKEN_NAME = "__RequestVerificationToken";

        public void OnAuthorization(AuthorizationContext filterContext) {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            var request = filterContext.HttpContext.Request;
            var cookie = request.Cookies[AntiForgeryConfig.CookieName];
            var cookieToken = cookie != null ? cookie.Value : null;
            var formToken = (request.IsAjaxRequest() ? request.Headers : request.Form)[TOKEN_NAME];

            AntiForgery.Validate(cookieToken, formToken);
        }
    }
}
