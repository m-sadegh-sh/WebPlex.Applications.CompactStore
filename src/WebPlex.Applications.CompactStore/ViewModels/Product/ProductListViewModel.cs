namespace WebPlex.Applications.CompactStore.ViewModels {
    using System.Collections.Generic;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Mvc;

    public sealed class ProductListViewModel : List<ProductModel> {
        public ProductListViewModel(IEnumerable<ProductModel> collection) : base(collection) {}

        public CategoryModel Category { get; set; }
        public string Query { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public UrlToken<SortOrder> Order { get; set; }
        public UrlToken<SortDirection> Direction { get; set; }
        public int TotalItemsCount { get; set; }

        public int? NextPage {
            get { return TotalItemsCount > Page*Size ? (int?) Page + 1 : null; }
        }

        public bool HasNextPage {
            get { return NextPage != null; }
        }
    }
}
