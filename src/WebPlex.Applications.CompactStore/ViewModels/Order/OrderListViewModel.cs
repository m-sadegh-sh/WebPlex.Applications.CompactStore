namespace WebPlex.Applications.CompactStore.ViewModels {
    using System.Collections.Generic;
    using WebPlex.Applications.CompactStore.Models;

    public sealed class OrderListViewModel : List<OrderModel> {
        public OrderListViewModel(IEnumerable<OrderModel> collection) : base(collection) {}

        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalItemsCount { get; set; }

        public int? NextPage {
            get { return TotalItemsCount > Page*Size ? (int?) Page + 1 : null; }
        }

        public bool HasNextPage {
            get { return NextPage != null; }
        }
    }
}
