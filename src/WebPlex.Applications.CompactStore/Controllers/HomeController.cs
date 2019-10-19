namespace WebPlex.Applications.CompactStore.Controllers {
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Data.Repositories;
    using WebPlex.Applications.CompactStore.Mapping;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Properties;

    public partial class HomeController : StoreController {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository) {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public virtual ActionResult Root() {
            return RedirectToAction(MVC.Product.List(null, null, null, null, null));
        }

        [HttpGet]
        public virtual ActionResult About() {
            throw new NotImplementedException();
        }

        [HttpGet]
        public virtual ActionResult Contact() {
            throw new NotImplementedException();
        }

        [HttpGet]
        [OutputCache(CacheProfile = "Home-Sitemap")]
        public virtual ActionResult Sitemap() {
            var model = new SitemapModel(new[] {
                MapHelpers.Map(Url, MVC.Product.List(null, null, null, null, null))
            });

            var categories = _categoryRepository.GetAll();
            var products = _productRepository.GetAll();

            foreach (var sitemap in categories.ToList().Select(c => MapHelpers.Map(Url, c)))
                model.Add(sitemap);

            foreach (var sitemap in products.ToList().Select(p => MapHelpers.Map(Url, p)))
                model.Add(sitemap);

            model.Add(MapHelpers.Map(Url, MVC.Home.Sitemap()));

            return Sitemap(model);
        }

        public virtual ActionResult Error(ErrorHandlingModel error) {
            Response.TrySkipIisCustomErrors = true;

            var model = new ErrorSummaryModel();

            switch (error.HttpCode) {
                case HttpStatusCode.Forbidden:
                    Response.StatusCode = model.ErrorNum = 403;
                    model.Heading = Resources.Error_Error_403;
                    model.Message = Resources.Error_Error_403Description;
                    break;

                case HttpStatusCode.NotFound:
                    Response.StatusCode = model.ErrorNum = 404;
                    model.Heading = Resources.Error_Error_404;
                    model.Message = Resources.Error_Error_404Description;
                    if (!string.IsNullOrEmpty(error.ErrorMessage) && !error.ErrorMessage.Contains(@"System.Web.HttpException"))
                        model.ErrorMessage = error.ErrorMessage;
                    break;

                default:
                    Response.StatusCode = model.ErrorNum = 500;
                    model.Heading = Resources.Error_Error_500;
                    model.Message = Resources.Error_Error_500Description;
                    break;
            }

            if (error.IsAjaxRequest)
                return Json(model, JsonRequestBehavior.AllowGet);

            return View(Views.Error, model);
        }
    }
}
