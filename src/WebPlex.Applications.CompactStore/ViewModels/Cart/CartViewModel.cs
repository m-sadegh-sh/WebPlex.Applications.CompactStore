namespace WebPlex.Applications.CompactStore.ViewModels {
    using System.Collections.Generic;
    using WebPlex.Applications.CompactStore.Models;

    public sealed class CartViewModel : List<CartItemModel> {
        public CartViewModel(IEnumerable<CartItemModel> collection) : base(collection) {}
    }
}
