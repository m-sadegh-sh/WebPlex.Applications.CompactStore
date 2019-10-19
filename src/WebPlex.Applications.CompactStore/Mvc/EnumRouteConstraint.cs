namespace WebPlex.Applications.CompactStore.Mvc {
    using System.Linq;
    using System.Web.Mvc.Routing.Constraints;
    using Dnum;
    using WebPlex.Applications.CompactStore.Helpers;

    public sealed class EnumRouteConstraint<TEnum> : RegexRouteConstraint where TEnum : struct {
        public EnumRouteConstraint() : base(string.Join("|", Dnum<TEnum>.GetNames().Select(StringHelpers.Slugify))) {}
    }
}
