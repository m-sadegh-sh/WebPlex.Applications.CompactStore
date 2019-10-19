namespace WebPlex.Applications.CompactStore.Mvc {
    using System;
    using System.Threading;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class DelayOnAsyncAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
                Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}
