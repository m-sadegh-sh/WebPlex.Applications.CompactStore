namespace WebPlex.Applications.CompactStore.Comparison {
    using System.Collections.Generic;
    using WebPlex.Applications.CompactStore.Configuration;
    using WebPlex.Applications.CompactStore.Models;

    public sealed class ProductComparer : IComparer<ProductModel> {
        public int Compare(ProductModel @this, ProductModel other) {
            return GetOrderWeight(@this) - GetOrderWeight(other);
        }

        private static int GetOrderWeight(ProductModel product) {
            if (product == null)
                return default (int);

            var computedViewsCount = product.ViewsCount*AppConfiguration.Current.ViewsCountFactor;
            var computedAddedToCartCount = product.AddedToCartCount*AppConfiguration.Current.AddedToCartCountFactor;

            return (int) (computedViewsCount + computedAddedToCartCount);
        }
    }
}
