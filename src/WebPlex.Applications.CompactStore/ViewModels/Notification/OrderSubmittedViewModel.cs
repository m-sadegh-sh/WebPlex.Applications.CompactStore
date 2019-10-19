namespace WebPlex.Applications.CompactStore.ViewModels {
    using System.Collections.Generic;
    using WebPlex.Applications.CompactStore.Models;

    public class OrderSubmittedViewModel {
        public CustomerModel Customer { get; set; }
        public OrderModel Order { get; set; }
        public IEnumerable<OrderLineModel> OrderLines { get; set; }
    }
}
