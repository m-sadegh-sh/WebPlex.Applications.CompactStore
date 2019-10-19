using System.Web;
using WebPlex.Applications.CompactStore.AppStart;

[assembly: PreApplicationStartMethod(typeof (BundleRegisterar), "RegisterBundles")]

namespace WebPlex.Applications.CompactStore.AppStart {
    using System.Web.Optimization;

    public static class BundleRegisterar {
        public static void RegisterBundles() {
            var bundles = BundleTable.Bundles;

            bundles.Add(new ScriptBundle("~/Assets/Scripts/jQuery").Include("~/Assets/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/Assets/Scripts/jQuery-Validate").Include("~/Assets/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/Assets/Scripts/jQuery-Ajax").Include("~/Assets/Scripts/jquery.unobtrusive*"));
            bundles.Add(new ScriptBundle("~/Assets/Scripts/jQuery-Scrolling").Include("~/Assets/Scripts/jquery.jscrollpane.js", "~/Assets/Scripts/jquery.mousewheel.js"));
            bundles.Add(new ScriptBundle("~/Assets/Scripts/Galleria").Include("~/Assets/Scripts/galleria-{version}.js", "~/Assets/Scripts/galleria.classic.js"));

            bundles.Add(new ScriptBundle("~/Assets/Scripts/Store").Include("~/Assets/Scripts/store.*"));

            bundles.Add(new StyleBundle("~/Assets/Styles/Store").Include("~/Assets/Styles/store.*"));
        }
    }
}
