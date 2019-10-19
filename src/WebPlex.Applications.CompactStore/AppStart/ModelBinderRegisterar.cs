using System.Web;
using WebPlex.Applications.CompactStore.AppStart;

[assembly: PreApplicationStartMethod(typeof (ModelBinderRegisterar), "RegisterModelBinders")]

namespace WebPlex.Applications.CompactStore.AppStart {
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Mvc;

    public static class ModelBinderRegisterar {
        public static void RegisterModelBinders() {
            var binders = ModelBinders.Binders;

            binders.DefaultBinder = new UrlTokenBinder();
        }
    }
}
