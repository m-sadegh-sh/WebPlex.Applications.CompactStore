namespace WebPlex.Applications.CompactStore.Controllers {
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Data.Repositories;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Properties;
    using WebPlex.Applications.CompactStore.ViewModels;

    public partial class CartController : StoreController {
        private readonly IProductRepository _productRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public CartController(IProductRepository productRepository, ICartItemRepository cartItemRepository) {
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult Form(string returnUrl) {
            var collection = _cartItemRepository.GetAll();

            var model = new CartViewModel(collection);

            return ViewAsync(Views.Form, Views._Form, model);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult Add(int id, string returnUrl) {
            var product = _productRepository.GetById(id);

            if (product == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Product);

            var cartItem = _cartItemRepository.GetById(id);

            if (cartItem != null)
                cartItem.Count++;
            else {
                cartItem = new CartItemModel {
                    Id = product.Id,
                    Title = product.Title,
                    Count = 1,
                    UnitPrice = product.UnitPrice
                };
            }

            _cartItemRepository.AddOrUpdate(cartItem);
            _cartItemRepository.SaveChanges();

            product.AddedToCartCount++;

            _productRepository.AddOrUpdate(product);
            _productRepository.SaveChanges();

            return RedirectedAsync(returnUrl, CartOperationModel.Succeeded(_cartItemRepository.GetItemsCount(), Resources.Success_AddedToCart));
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult Remove(int id, bool removeAll, string returnUrl) {
            var product = _productRepository.GetById(id);

            if (product == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Product);

            var cartItem = _cartItemRepository.GetById(id);

            if (cartItem != null) {
                if (removeAll) {
                    product.AddedToCartCount--;
                    cartItem.Count = 0;
                } else {
                    product.AddedToCartCount--;
                    cartItem.Count--;
                }

                if (cartItem.Count == 0) {
                    _cartItemRepository.Delete(new CartItemModel {
                        Id = product.Id,
                        Title = product.Title,
                        UnitPrice = product.UnitPrice
                    });
                }

                _cartItemRepository.SaveChanges();

                _productRepository.AddOrUpdate(product);
                _productRepository.SaveChanges();
            }

            return RedirectedAsync(returnUrl, CartOperationModel.Succeeded(_cartItemRepository.GetItemsCount(), Resources.Success_RemovedFromCart));
        }
    }
}
