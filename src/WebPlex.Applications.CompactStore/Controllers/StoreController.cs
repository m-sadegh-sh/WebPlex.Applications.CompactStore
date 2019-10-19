namespace WebPlex.Applications.CompactStore.Controllers {
    using System.IO;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Mvc;

    public abstract partial class StoreController : Controller
    {
        protected ActionResult ViewAsync(string viewName, string partialViewName, object model = null) {
            if (Request.IsAjaxRequest())
                return PartialView(partialViewName, model);

            return View(viewName, model);
        }

        protected ActionResult RedirectedAsync(string returnUrl, string message = null, bool failed = false) {
            OperationModel result;

            if (failed)
                result = RedirectOperationModel.Failed(returnUrl, message);
            else
                result = RedirectOperationModel.Succeeded(returnUrl, message);

            return RedirectedAsync(returnUrl, result);
        }

        protected ActionResult RedirectedAsync(string returnUrl, OperationModel result) {
            if (Request.IsAjaxRequest())
                return Json(result);

            AddResult(result);
            return Redirect(returnUrl);
        }

        protected ActionResult FailedAsync(string viewName, string partialViewName, object model, string message) {
            var result = OperationModel.Failed(message);

            if (Request.IsAjaxRequest()) {
                result.Content = RenderedPartialView(partialViewName, model);

                return Json(result);
            }

            AddResult(result);
            return View(viewName, model);
        }

        protected ActionResult SucceededAsync(string viewName, string partialViewName, object model, string message) {
            var result = OperationModel.Succeeded(message);

            if (Request.IsAjaxRequest()) {
                result.Content = RenderedPartialView(partialViewName, model);

                return Json(result);
            }

            AddResult(result);
            return View(viewName, model);
        }

        private void AddResult(OperationModel result) {
            TempDateHelpers.AddResult(TempData, result);
        }

        private string RenderedPartialView(string viewName, object model) {
            ViewData.Model = model;

            using (var writer = new StringWriter()) {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, writer);

                viewResult.View.Render(viewContext, writer);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                return writer.GetStringBuilder().ToString();
            }
        }

        protected virtual SitemapResult Sitemap(SitemapModel model) {
            return new SitemapResult(model);
        }
    }
}
