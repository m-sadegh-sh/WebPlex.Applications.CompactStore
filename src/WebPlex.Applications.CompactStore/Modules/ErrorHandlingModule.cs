namespace WebPlex.Applications.CompactStore.Modules {
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Logging;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Mvc;

    public sealed class ErrorHandlingModule : IHttpModule {
        public static Lazy<Func<ErrorHandlingModel, ActionResult>> RedirectionResult { private get; set; }

        public void Init(HttpApplication context) {
            context.Error += OnError;
        }

        private static void OnError(object sender, EventArgs e) {
            if (HostingEnvironment.IsDevelopmentEnvironment)
                return;

            var application = (HttpApplication) sender;
            var context = application.Context;
            var request = new HttpRequestWrapper(context.Request);
            var server = application.Server;

            var exception = server.GetLastError();
            if (exception == null)
                return;

            LogHelpers.Write(exception);

            var httpException = exception as HttpException ?? new HttpException(null, exception);

            var errorInfo = new ErrorHandlingModel {
                HttpCode = (HttpStatusCode) httpException.GetHttpCode(),
                ErrorMessage = httpException.Message,
                RequestUrl = request.Url,
                IsAjaxRequest = request.IsAjaxRequest(),
                HttpMethod = request.HttpMethod
            };

            var result = RedirectionResult.Value(errorInfo);

            server.ClearError();
            context.ExecuteAction(result);
        }

        public void Dispose() {}
    }
}
