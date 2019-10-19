namespace WebPlex.Applications.CompactStore.Modules {
    using System;
    using System.Linq;
    using System.Web;

    public sealed class UrlNormalizerModule : IHttpModule {
        public void Init(HttpApplication context) {
            context.BeginRequest += OnBeginRequest;
        }

        private static void OnBeginRequest(object sender, EventArgs e) {
            var context = ((HttpApplication) sender).Context;
            var request = context.Request;
            var response = context.Response;
            var scheme = request.Url.Scheme;
            var host = request.Url.Host;
            var path = request.Url.AbsolutePath;
            var query = request.Url.Query;

            var isPost = string.Equals(request.HttpMethod, "POST", StringComparison.CurrentCulture);
            var hasAnyUppercase = path.Any(char.IsUpper);
            var trailingSlashNeeded = string.IsNullOrEmpty(request.CurrentExecutionFilePathExtension) && !path.EndsWith("/") && string.IsNullOrEmpty(query);
            var wwwRemovalNeeded = host.StartsWith("www.");

            if (isPost || (!hasAnyUppercase && !trailingSlashNeeded && !wwwRemovalNeeded))
                return;

            var normalizedUrl = string.Format("{0}://{1}", scheme, host);

            if (wwwRemovalNeeded)
                normalizedUrl = normalizedUrl.Replace("www.", "");

            normalizedUrl += path.ToLowerInvariant().TrimEnd('/');

            if (trailingSlashNeeded)
                normalizedUrl += "/";

            normalizedUrl += query;

            response.RedirectPermanent(normalizedUrl);
        }

        public void Dispose() {}
    }
}
