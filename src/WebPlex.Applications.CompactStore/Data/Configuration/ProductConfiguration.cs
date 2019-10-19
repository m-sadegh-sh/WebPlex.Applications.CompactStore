namespace WebPlex.Applications.CompactStore.Data.Configuration {
    using WebPlex.Applications.CompactStore.Models;

    public sealed class ProductConfiguration : EntityConfigurationBase<ProductModel> {
        public ProductConfiguration() {
            ToTable("Products");
            HasRequired(p => p.Category).WithMany().Map(fk => fk.MapKey("CategoryId")).WillCascadeOnDelete(false);
            Property(p => p.Title).HasMaxLength(512).IsRequired();
            Property(p => p.Slug).HasMaxLength(256).IsRequired();
            Property(p => p.Summary).IsMaxLength();
            Property(p => p.Description).IsMaxLength().IsRequired();
            Property(p => p.MetaKeywords).IsMaxLength();
            Property(p => p.MetaDescription).IsMaxLength();
            Property(p => p.Features).IsMaxLength();
            Property(p => p.UnitPrice);
            Property(p => p.ReleaseDateUtc);
            Property(p => p.LastModifiedDateUtc);
            Property(p => p.ViewsCount);
            Property(p => p.AddedToCartCount);
        }
    }
}
