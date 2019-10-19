namespace WebPlex.Applications.CompactStore.Mvc {
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using WebPlex.Applications.CompactStore.Routing;

    public static class ActionExecutionHelpers {
        public static void ExecuteAction(this HttpContext context, ActionResult result) {
            new HttpContextWrapper(context).ExecuteAction(result);
        }

        public static void ExecuteAction(this HttpContextBase context, ActionResult result) {
            var response = context.Response;

            var controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            var controllerName = result.GetT4MVCResult().Controller;
            var routeValues = result.GetRouteValueDictionary();

            var routeData = new RouteData();
            routeData.Values.Overwrite(routeValues);

            var requestContext = new RequestContext(context, routeData);

            var controller = controllerFactory.CreateController(requestContext, controllerName);

            controller.Execute(requestContext);

            response.End();
        }
    }
}
