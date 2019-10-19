namespace WebPlex.Applications.CompactStore.Mvc {
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    public static class HtmlStringExtensions {
        public static MvcHtmlString UseContent(this MvcHtmlString htmlString, string richContent) {
            var rawString = htmlString.ToHtmlString();

            var match = Regex.Match(rawString, @"<[\w]*[[\s+].*]*>\s*(.+?)\s*</[\w]*>");
            if (match.Success) {
                var plainContent = match.Groups[1].Value;
                richContent = string.Format(richContent, plainContent);

                plainContent = string.Format(">{0}<", plainContent);
                richContent = string.Format(">{0}<", richContent);
                rawString = rawString.Replace(plainContent, richContent);
            }

            return new MvcHtmlString(rawString);
        }
    }
}
