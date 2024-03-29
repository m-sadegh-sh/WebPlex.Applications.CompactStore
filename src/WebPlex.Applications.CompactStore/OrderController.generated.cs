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
    public partial class OrderController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected OrderController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult ValidateAccessToken()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ValidateAccessToken);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult List()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.List);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Cancel()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Cancel);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CheckOut()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckOut);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult PreparePaymentRequest()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PreparePaymentRequest);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Track()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Track);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OrderController Actions { get { return MVC.Order; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Order";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Order";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string ValidateAccessToken = "ValidateAccessToken";
            public readonly string Submit = "Submit";
            public readonly string List = "List";
            public readonly string Cancel = "Cancel";
            public readonly string CheckOut = "CheckOut";
            public readonly string PreparePaymentRequest = "PreparePaymentRequest";
            public readonly string Track = "Track";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string ValidateAccessToken = "ValidateAccessToken";
            public const string Submit = "Submit";
            public const string List = "List";
            public const string Cancel = "Cancel";
            public const string CheckOut = "CheckOut";
            public const string PreparePaymentRequest = "PreparePaymentRequest";
            public const string Track = "Track";
        }


        static readonly ActionParamsClass_ValidateAccessToken s_params_ValidateAccessToken = new ActionParamsClass_ValidateAccessToken();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ValidateAccessToken ValidateAccessTokenParams { get { return s_params_ValidateAccessToken; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ValidateAccessToken
        {
            public readonly string accessToken = "accessToken";
        }
        static readonly ActionParamsClass_List s_params_List = new ActionParamsClass_List();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_List ListParams { get { return s_params_List; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_List
        {
            public readonly string page = "page";
            public readonly string size = "size";
        }
        static readonly ActionParamsClass_Cancel s_params_Cancel = new ActionParamsClass_Cancel();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Cancel CancelParams { get { return s_params_Cancel; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Cancel
        {
            public readonly string accessToken = "accessToken";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_CheckOut s_params_CheckOut = new ActionParamsClass_CheckOut();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CheckOut CheckOutParams { get { return s_params_CheckOut; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CheckOut
        {
            public readonly string accessToken = "accessToken";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_PreparePaymentRequest s_params_PreparePaymentRequest = new ActionParamsClass_PreparePaymentRequest();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_PreparePaymentRequest PreparePaymentRequestParams { get { return s_params_PreparePaymentRequest; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_PreparePaymentRequest
        {
            public readonly string accessToken = "accessToken";
        }
        static readonly ActionParamsClass_Track s_params_Track = new ActionParamsClass_Track();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Track TrackParams { get { return s_params_Track; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Track
        {
            public readonly string accessToken = "accessToken";
            public readonly string model = "model";
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
                public readonly string _CheckOut = "_CheckOut";
                public readonly string _List = "_List";
                public readonly string _Track = "_Track";
                public readonly string CheckOut = "CheckOut";
                public readonly string List = "List";
                public readonly string Track = "Track";
            }
            public readonly string _CheckOut = "~/Views/Order/_CheckOut.cshtml";
            public readonly string _List = "~/Views/Order/_List.cshtml";
            public readonly string _Track = "~/Views/Order/_Track.cshtml";
            public readonly string CheckOut = "~/Views/Order/CheckOut.cshtml";
            public readonly string List = "~/Views/Order/List.cshtml";
            public readonly string Track = "~/Views/Order/Track.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_OrderController : WebPlex.Applications.CompactStore.Controllers.OrderController
    {
        public T4MVC_OrderController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ValidateAccessTokenOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string accessToken);

        [NonAction]
        public override System.Web.Mvc.ActionResult ValidateAccessToken(string accessToken)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ValidateAccessToken);
		if (accessToken != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "accessToken", accessToken);
            ValidateAccessTokenOverride(callInfo, accessToken);
            return callInfo;
        }

        [NonAction]
        partial void SubmitOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Submit()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Submit);
            SubmitOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? page, int? size);

        [NonAction]
        public override System.Web.Mvc.ActionResult List(int? page, int? size)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.List);
		if (page != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "page", page);
		if (size != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "size", size);
            ListOverride(callInfo, page, size);
            return callInfo;
        }

        [NonAction]
        partial void CancelOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string accessToken, string returnUrl);

        [NonAction]
        public override System.Web.Mvc.ActionResult Cancel(string accessToken, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Cancel);
		if (accessToken != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "accessToken", accessToken);
		if (returnUrl != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            CancelOverride(callInfo, accessToken, returnUrl);
            return callInfo;
        }

        [NonAction]
        partial void CheckOutOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string accessToken);

        [NonAction]
        public override System.Web.Mvc.ActionResult CheckOut(string accessToken)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckOut);
		if (accessToken != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "accessToken", accessToken);
            CheckOutOverride(callInfo, accessToken);
            return callInfo;
        }

        [NonAction]
        partial void CheckOutOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, WebPlex.Applications.CompactStore.ViewModels.CheckOutViewModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult CheckOut(WebPlex.Applications.CompactStore.ViewModels.CheckOutViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckOut);
		if (model != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            CheckOutOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void PreparePaymentRequestOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string accessToken);

        [NonAction]
        public override System.Web.Mvc.ActionResult PreparePaymentRequest(string accessToken)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PreparePaymentRequest);
		if (accessToken != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "accessToken", accessToken);
            PreparePaymentRequestOverride(callInfo, accessToken);
            return callInfo;
        }

        [NonAction]
        partial void TrackOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string accessToken);

        [NonAction]
        public override System.Web.Mvc.ActionResult Track(string accessToken)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Track);
		if (accessToken != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "accessToken", accessToken);
            TrackOverride(callInfo, accessToken);
            return callInfo;
        }

        [NonAction]
        partial void TrackOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, WebPlex.Applications.CompactStore.ViewModels.TrackViewModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult Track(WebPlex.Applications.CompactStore.ViewModels.TrackViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Track);
		if (model != null)
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            TrackOverride(callInfo, model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108
