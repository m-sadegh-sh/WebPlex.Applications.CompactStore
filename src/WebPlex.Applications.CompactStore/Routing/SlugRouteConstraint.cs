namespace WebPlex.Applications.CompactStore.Routing {
    using System;
    using System.Web;
    using System.Web.Routing;
    using WebPlex.Applications.CompactStore.Helpers;

    public sealed class SlugRouteConstraint : IRouteConstraint {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {
            object value;
            return values.TryGetValue(parameterName, out value) && value != null && string.Compare(value.ToString(), StringHelpers.Slugify(value.ToString()), StringComparison.CurrentCulture) == 0;
        }
    }
}
