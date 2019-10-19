namespace WebPlex.Applications.CompactStore.Models {
    public class ValidateOperationModel : OperationModel {
        protected ValidateOperationModel(OperationType type, string message, string property) : base(type, message) {
            Property = property;
        }

        public string Property { get; set; }

        public static OperationModel Failed(string message, string property) {
            return new ValidateOperationModel(OperationType.Failed, message, property);
        }
    }
}
