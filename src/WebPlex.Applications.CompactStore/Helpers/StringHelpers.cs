namespace WebPlex.Applications.CompactStore.Helpers {
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Hosting;
    using System.Web.Mvc;

    public static class StringHelpers {
        public static IHtmlString ConvertToString(IEnumerable<KeyValuePair<string, object>> attributes) {
            var result = new StringBuilder();

            foreach (var attribute in attributes)
                result.AppendFormat(@"{0}=""{1}"" ", attribute.Key, attribute.Value);

            return MvcHtmlString.Create(result.ToString().Trim());
        }

        public static string Slugify(string value) {
            var builder = new StringBuilder();
            foreach (var ch in value) {
                if (char.IsUpper(ch))
                    builder.Append("-");

                builder.Append(ch);
            }

            var slug = builder.ToString();
            slug = Regex.Replace(slug, @"[^A-Za-z0-9\s-\u0600\u06FF\uFB8A\u067E\u0686\u06AF]", "");
            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            slug = Regex.Replace(slug, @"\s", "-");

            while (slug.Contains("--"))
                slug = slug.Replace("--", "-");

            slug = slug.Trim('-');
            slug = slug.ToLowerInvariant();

            return slug;
        }

        public static string Unslugify(string slug) {
            var builder = new StringBuilder();
            var firstChar = true;
            var dashCaptured = false;

            foreach (var ch in slug) {
                if (ch == '-') {
                    dashCaptured = true;
                    continue;
                }

                if (firstChar || dashCaptured) {
                    builder.Append(char.ToUpper(ch));
                    firstChar = false;
                    dashCaptured = false;
                } else
                    builder.Append(ch);
            }

            var value = builder.ToString();

            return value;
        }

        public static string ConvertPathToUrl(string path) {
            return path.Replace(HostingEnvironment.ApplicationPhysicalPath, HostingEnvironment.ApplicationVirtualPath).Replace("\\", "/");
        }
    }
}
