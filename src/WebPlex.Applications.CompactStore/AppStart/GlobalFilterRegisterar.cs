using System.Web;
using WebPlex.Applications.CompactStore.AppStart;

[assembly: PreApplicationStartMethod(typeof (GlobalFilterRegisterar), "RegisterGlobalFilters")]

namespace WebPlex.Applications.CompactStore.AppStart {
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Mvc;

    public static class GlobalFilterRegisterar {
        public static void RegisterGlobalFilters() {
            var filters = GlobalFilters.Filters;

            filters.Add(new DelayOnAsyncAttribute());
            filters.Add(new EnsureReturnUrlAttribute());
        }
    }
}
