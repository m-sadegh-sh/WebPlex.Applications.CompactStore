using System.Web;
using WebPlex.Applications.CompactStore.AppStart;

[assembly: PreApplicationStartMethod(typeof (ModulesRegisterar), "RegisterModules")]

namespace WebPlex.Applications.CompactStore.AppStart {
    using System;
    using System.Web.Mvc;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Modules;

    public static class ModulesRegisterar {
        public static void RegisterModules() {
            ErrorHandlingModule.RedirectionResult = new Lazy<Func<ErrorHandlingModel, ActionResult>>(() => error => MVC.Home.Error(error));
            //DynamicModuleUtility.RegisterModule(typeof (ErrorHandlingModule));
            DynamicModuleUtility.RegisterModule(typeof (UrlNormalizerModule));
        }
    }
}
