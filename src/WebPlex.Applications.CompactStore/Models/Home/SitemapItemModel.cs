namespace WebPlex.Applications.CompactStore.Models {
    using System;

    public sealed class SitemapItemModel {
        public string Url { get; set; }
        public DateTime? LastModified { get; set; }
        public ChangeFrequency? ChangeFrequency { get; set; }
        public float? Priority { get; set; }
    }
}
