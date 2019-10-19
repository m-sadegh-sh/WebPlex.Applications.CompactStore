namespace WebPlex.Applications.CompactStore.Mvc {
    using System.Linq;
    using System.Web.Mvc;
    using System.Xml.Linq;
    using WebPlex.Applications.CompactStore.Mapping;
    using WebPlex.Applications.CompactStore.Models;

    public class SitemapResult : ActionResult {
        private readonly XNamespace _namespace = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");
        private readonly SitemapModel _model;

        public SitemapResult(SitemapModel model) {
            _model = model;
        }

        public override void ExecuteResult(ControllerContext context) {
            var encoding = context.HttpContext.Response.ContentEncoding.WebName;
            var declaration = new XDeclaration("1.0", encoding, "yes");

            var mappedElements = from sitemap in _model
                                 select MapHelpers.Map(sitemap);

            var content = new XElement("urlset", _namespace, mappedElements);
            var sitemapDocument = new XDocument(declaration, content);

            context.HttpContext.Response.ContentType = "application/rss+xml";
            context.HttpContext.Response.Flush();
            context.HttpContext.Response.Write(sitemapDocument.Declaration + sitemapDocument.ToString());
        }
    }
}
