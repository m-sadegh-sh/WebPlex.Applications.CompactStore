namespace WebPlex.Applications.CompactStore.Mapping {
    using System;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Xml.Linq;
    using WebPlex.Applications.CompactStore.Models;

    public static class MapHelpers {
        public static SitemapItemModel Map(UrlHelper url, ActionResult result) {
            return new SitemapItemModel {
                Url = url.Action(result, "http"),
                LastModified = DateTime.UtcNow.ToLocalTime(),
                ChangeFrequency = ChangeFrequency.Daily,
                Priority = 1
            };
        }

        public static SitemapItemModel Map(UrlHelper url, CategoryModel category) {
            return new SitemapItemModel {
                Url = url.Action(MVC.Product.ListByCategory(category.Slug, null, null, null, null, null), "http"),
                LastModified = DateTime.UtcNow.ToLocalTime(),
                ChangeFrequency = ChangeFrequency.Daily,
                Priority = 1
            };
        }

        public static SitemapItemModel Map(UrlHelper url, ProductModel product) {
            return new SitemapItemModel {
                Url = url.Action(MVC.Product.Details(product.Category.Slug, product.Slug), "http"),
                LastModified = product.LastModifiedDateUtc.ToLocalTime(),
                ChangeFrequency = ChangeFrequency.Weekly,
                Priority = 1
            };
        }

        public static XElement Map(SitemapItemModel sitemap) {
            var element = new XElement("url", new XElement("loc", sitemap.Url.ToLower()));

            if (sitemap.LastModified != null)
                element.Add(new XElement("lastmod", ((DateTime) sitemap.LastModified).ToString("yyyy-MM-dd")));

            if (sitemap.ChangeFrequency != null)
                element.Add(new XElement("changefreq", ((ChangeFrequency) sitemap.ChangeFrequency).ToString().ToLower()));

            if (sitemap.Priority != null)
                element.Add(new XElement("priority", ((float) sitemap.Priority).ToString(CultureInfo.InvariantCulture)));

            return element;
        }
    }
}
