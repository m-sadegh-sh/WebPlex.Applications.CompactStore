namespace WebPlex.Applications.CompactStore.Models {
    public class CustomerOperationModel : OperationModel {
        protected CustomerOperationModel(OperationType type, CustomerModel customer) : base(type, null) {
            Customer = customer;
        }

        public CustomerModel Customer { get; set; }

        public static CustomerOperationModel Succeeded(CustomerModel customer) {
            return new CustomerOperationModel(OperationType.Succeeded, customer);
        }
    }
}
