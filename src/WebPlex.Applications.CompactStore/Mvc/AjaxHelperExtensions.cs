namespace WebPlex.Applications.CompactStore.Mvc {
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Routing;
    using WebPlex.Applications.CompactStore.Helpers;
    using WebPlex.Applications.CompactStore.Routing;

    public static class AjaxHelperExtensions {
        public static MvcHtmlString NormalizedActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions, object htmlAttributes) {
            var normalizedHtmlAttributes = new RouteValueDictionary();
            var originHtmlAttributes = htmlAttributes.Convert();
            foreach (var attribute in originHtmlAttributes) {
                if (attribute.Value != null)
                    normalizedHtmlAttributes.Add(attribute.Key, attribute.Value);
            }

            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions, normalizedHtmlAttributes);
        }

        public static AjaxOptions Options(this AjaxHelper ajaxHelper, string updateTargetId = null, bool replace = true, string onBegin = null, string onSuccess = null, string onFailure = null, string onComplete = null) {
            return new AjaxOptions {
                LoadingElementId = "WebPlex-AsyncIndicator",
                HttpMethod = FormMethod.Post.ToString(),
                InsertionMode = replace ? InsertionMode.Replace : InsertionMode.InsertAfter,
                UpdateTargetId = updateTargetId,
                OnBegin = onBegin,
                OnSuccess = onSuccess,
                OnFailure = onFailure,
                OnComplete = onComplete
            };
        }

        public static IHtmlString OptionsString(this AjaxHelper ajaxHelper, string updateTargetId = null, bool replace = true, string onBegin = null, string onSuccess = null, string onFailure = null, string onComplete = null) {
            return StringHelpers.ConvertToString(Options(ajaxHelper, updateTargetId, replace, onBegin, onSuccess, onFailure, onComplete).ToUnobtrusiveHtmlAttributes());
        }
    }
}
