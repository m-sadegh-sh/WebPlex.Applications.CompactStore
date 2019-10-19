namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Collections.Generic;
    using WebPlex.Applications.CompactStore.Models;

    public interface IProductRepository : IRepository<ProductModel> {
        IDictionary<int, ProductModel> GetAllByIds(params int[] ids);
        ProductModel GetBySlug(string slug);
        IEnumerable<ProductModel> GetProducts(CategoryModel category, string query, SortOrder order, SortDirection direction, ref int? page, ref int? size, out int totalItemsCount);
    }
}
