namespace WebPlex.Applications.CompactStore.ViewModels {
    using WebPlex.Applications.CompactStore.Models;

    public sealed class CheckOutViewModel {
        public OrderModel Order { get; set; }
        public CheckOutType CheckOutType { get; set; }
    }
}
