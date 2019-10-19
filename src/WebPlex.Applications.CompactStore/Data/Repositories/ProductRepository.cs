namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using WebPlex.Applications.CompactStore.Comparison;
    using WebPlex.Applications.CompactStore.Configuration;
    using WebPlex.Applications.CompactStore.Models;

    public class ProductRepository : DbRepositoryBase<ProductModel>, IProductRepository {
        public ProductRepository(StoreContext context) : base(context) {}

        public IDictionary<int, ProductModel> GetAllByIds(params int[] ids) {
            return GetAll().Where(p => ids.Contains(p.Id)).ToDictionary(p => p.Id, p => p);
        }

        public ProductModel GetBySlug(string slug) {
            return GetAll().SingleOrDefault(p => string.Compare(p.Slug, slug, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public IEnumerable<ProductModel> GetProducts(CategoryModel category, string query, SortOrder order, SortDirection direction, ref int? page, ref int? size, out int totalItemsCount) {
            page = page.GetValueOrDefault(1);
            size = size.GetValueOrDefault(AppConfiguration.Current.DefaultPageSize);

            var products = GetAll();

            if (category != null)
                products = products.Where(p => p.Category.Id == category.Id);

            if (!string.IsNullOrEmpty(query))
                products = products.Where(p => p.Title.Contains(query) || p.Summary.Contains(query) || p.Description.Contains(query));

            totalItemsCount = products.Count();

            switch (order) {
                case SortOrder.Default:
                    if (direction == SortDirection.Ascending)
                        products = products.ToList().AsQueryable().OrderBy(p => p, new ProductComparer());
                    else
                        products = products.ToList().AsQueryable().OrderByDescending(p => p, new ProductComparer());

                    break;

                case SortOrder.ReleaseDateUtc:
                    if (direction == SortDirection.Ascending)
                        products = products.OrderBy(p => p.ReleaseDateUtc);
                    else
                        products = products.OrderByDescending(p => p.ReleaseDateUtc);

                    break;
                case SortOrder.UnitPrice:
                    if (direction == SortDirection.Ascending)
                        products = products.OrderBy(p => p.UnitPrice);
                    else
                        products = products.OrderByDescending(p => p.UnitPrice);

                    break;
            }

            products = products.Skip(((int) page - 1)*(int) size).Take((int) size);

            return products.ToList();
        }

        protected override IQueryable<ProductModel> GetIncluded(IQueryable<ProductModel> queryable) {
            return queryable.Include(p => p.Category);
        }
    }
}
