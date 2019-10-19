namespace WebPlex.Applications.CompactStore.Models {
    using System;
    using System.Net;

    public sealed class ErrorHandlingModel {
        public HttpStatusCode HttpCode { get; set; }
        public string ErrorMessage { get; set; }
        public Uri RequestUrl { get; set; }
        public bool IsAjaxRequest { get; set; }
        public string HttpMethod { get; set; }
    }
}
