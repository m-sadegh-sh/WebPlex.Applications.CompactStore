namespace WebPlex.Applications.CompactStore.Models {
    public class OperationModel {
        protected OperationModel(OperationType type, string message) {
            Type = type;
            Message = message;
        }

        public OperationType Type { get; set; }
        public string Message { get; set; }
        public string Content { get; set; }

        public static OperationModel Failed(string message) {
            return new OperationModel(OperationType.Failed, message);
        }

        public static OperationModel Succeeded(string message) {
            return new OperationModel(OperationType.Succeeded, message);
        }
    }
}
