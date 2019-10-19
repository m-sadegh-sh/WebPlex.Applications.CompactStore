namespace WebPlex.Applications.CompactStore.Models {
    using System.Collections.Generic;

    public sealed class SitemapModel : List<SitemapItemModel> {
        public SitemapModel(IEnumerable<SitemapItemModel> collection) : base(collection) {}
    }
}
