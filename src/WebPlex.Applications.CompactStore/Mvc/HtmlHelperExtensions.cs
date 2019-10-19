namespace WebPlex.Applications.CompactStore.Mvc {
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HtmlHelperExtensions {
        public static string GetModelState<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> property, string additionalClasses) {
            var modelStateClass = "";
            var state = html.ViewContext.ViewData.ModelState[html.NameFor(property).ToString()];

            if (state != null && state.Errors.Any())
                modelStateClass = " WebPlex-Wrong";

            return additionalClasses + modelStateClass;
        }

        public static IHtmlString Raw(this HtmlHelper html, string format, params object[] args) {
            return html.Raw(string.Format(format, args));
        }
    }
}
