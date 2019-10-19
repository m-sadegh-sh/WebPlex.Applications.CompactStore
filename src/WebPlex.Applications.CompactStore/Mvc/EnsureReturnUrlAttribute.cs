namespace WebPlex.Applications.CompactStore.Mvc {
    using System;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class EnsureReturnUrlAttribute : ActionFilterAttribute {
        private const string PARAMETER_NAME = "returnUrl";

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (!filterContext.ActionParameters.ContainsKey(PARAMETER_NAME))
                filterContext.ActionParameters.Add(PARAMETER_NAME, null);

            var urlHelper = new UrlHelper(filterContext.RequestContext);
            var value = filterContext.ActionParameters[PARAMETER_NAME] as string;

            if (value == null || !urlHelper.IsLocalUrl(value))
                value = urlHelper.Action(MVC.Home.Root());

            filterContext.ActionParameters[PARAMETER_NAME] = value;
            filterContext.Controller.ViewBag.ReturnUrl = value;
        }
    }
}
