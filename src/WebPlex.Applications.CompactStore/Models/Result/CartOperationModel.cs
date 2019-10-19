namespace WebPlex.Applications.CompactStore.Models {
    public class CartOperationModel : OperationModel {
        private CartOperationModel(OperationType type, int cartItemsCount, string message) : base(type, message) {
            CartItemsCount = cartItemsCount;
        }

        public int CartItemsCount { get; set; }

        public static OperationModel Succeeded(int cartItemsCount, string message) {
            return new CartOperationModel(OperationType.Succeeded, cartItemsCount, message);
        }
    }
}
