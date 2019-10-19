namespace WebPlex.Applications.CompactStore.Controllers {
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Data.Repositories;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Mvc;
    using WebPlex.Applications.CompactStore.Properties;
    using WebPlex.Applications.CompactStore.ViewModels;

    public partial class ProductController : StoreController {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository) {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult List(string query, UrlToken<SortOrder> order, UrlToken<SortDirection> direction, int? page, int? size) {
            return List(null, query, order, direction, page, size);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult ListByCategory(string categorySlug, string query, UrlToken<SortOrder> order, UrlToken<SortDirection> direction, int? page, int? size) {
            return List(categorySlug, query, order, direction, page, size);
        }

        [OutputCache(CacheProfile = "Product-List")]
        private ActionResult List(string categorySlug, string query, UrlToken<SortOrder> order, UrlToken<SortDirection> direction, int? page, int? size) {
            CategoryModel category = null;

            if (!string.IsNullOrEmpty(categorySlug)) {
                category = _categoryRepository.GetBySlug(categorySlug);

                if (category == null)
                    throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Category);
            }

            int totalItemsCount;
            var collection = _productRepository.GetProducts(category, query, order, direction, ref page, ref size, out totalItemsCount);

            var viewModel = new ProductListViewModel(collection) {
                Category = category,
                Query = query,
                Page = page.GetValueOrDefault(),
                Size = size.GetValueOrDefault(),
                Order = order,
                Direction = direction,
                TotalItemsCount = totalItemsCount
            };

            return ViewAsync(Views.List, Views._List, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [OutputCache(CacheProfile = "Product-Details")]
        public virtual ActionResult Details(string categorySlug, string productSlug) {
            var product = _productRepository.GetBySlug(productSlug);

            if (product == null || string.Compare(product.Category.Slug, categorySlug, StringComparison.OrdinalIgnoreCase) != 0)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Product);

            product.ViewsCount++;

            _productRepository.AddOrUpdate(product);
            _productRepository.SaveChanges();

            return ViewAsync(Views.Details, Views._Details, product);
        }
    }
}
