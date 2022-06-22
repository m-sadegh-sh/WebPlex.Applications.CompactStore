// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
#pragma warning disable 1591, 3008, 3009, 0108
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace WebPlex.Applications.CompactStore.Controllers
{
    public partial class OptimizationController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OptimizationController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected OptimizationController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Image()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Image);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OptimizationController Actions { get { return MVC.Optimization; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Optimization";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Optimization";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Image = "Image";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Image = "Image";
        }


        static readonly ActionParamsClass_Image s_params_Image = new ActionParamsClass_Image();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Image ImageParams { get { return s_params_Image; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Image
        {
            public readonly string maximumWidth = "maximumWidth";
            public readonly string maximumHeight = "maximumHeight";
            public readonly string relativeUrl = "relativeUrl";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_OptimizationController : WebPlex.Applications.CompactStore.Controllers.OptimizationController
    {
        public T4MVC_OptimizationController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ImageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int maximumWidth, int maximumHeight, string relativeUrl);

        [NonAction]
        public override System.Web.Mvc.ActionResult Image(int maximumWidth, int maximumHeight, string relativeUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Image);
		if (maximumWidth != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "maximumWidth", maximumWidth);
		if (maximumHeight != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "maximumHeight", maximumHeight);
		if (relativeUrl != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "relativeUrl", relativeUrl);
            ImageOverride(callInfo, maximumWidth, maximumHeight, relativeUrl);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108