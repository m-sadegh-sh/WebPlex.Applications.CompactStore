namespace WebPlex.Applications.CompactStore.Routing {
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteHelpers {
        public static RouteValueDictionary Convert(this object source) {
            if (source == null)
                return new RouteValueDictionary();

            var dictionary = source as RouteValueDictionary;
            if (dictionary != null)
                return dictionary;

            return HtmlHelper.AnonymousObjectToHtmlAttributes(source);
        }

        public static void Overwrite(this object first, object second) {
            var result = Convert(first);

            foreach (var item in Convert(second)) {
                if (result.ContainsKey(item.Key))
                    result[item.Key] = item.Value;
                else
                    result.Add(item.Key, item.Value);
            }
        }

        public static RouteValueDictionary Normalize(this object source) {
            var result = Convert(source);

            foreach (var key in result.Keys.ToArray()) {
                if (result[key] == null || string.IsNullOrEmpty(result[key].ToString()))
                    result.Remove(key);
            }

            return result;
        }
    }
}
