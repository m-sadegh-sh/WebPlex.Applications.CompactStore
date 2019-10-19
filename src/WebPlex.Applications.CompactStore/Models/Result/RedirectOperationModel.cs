namespace WebPlex.Applications.CompactStore.Models {
    public class RedirectOperationModel : OperationModel {
        private RedirectOperationModel(OperationType type, string returnUrl, string message) : base(type, message) {
            ReturnUrl = returnUrl;
        }

        public string ReturnUrl { get; set; }

        public static OperationModel Failed(string returnUrl, string message) {
            return new RedirectOperationModel(OperationType.Failed, returnUrl, message);
        }

        public static OperationModel Succeeded(string returnUrl, string message) {
            return new RedirectOperationModel(OperationType.Succeeded, returnUrl, message);
        }
    }
}
