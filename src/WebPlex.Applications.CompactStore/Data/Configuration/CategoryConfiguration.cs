namespace WebPlex.Applications.CompactStore.Data.Configuration {
    using WebPlex.Applications.CompactStore.Models;

    public sealed class CategoryConfiguration : EntityConfigurationBase<CategoryModel> {
        public CategoryConfiguration() {
            ToTable("Categories");
            Property(c => c.DisplayOrder);
            Property(c => c.Title).HasMaxLength(512).IsRequired();
            Property(c => c.Slug).HasMaxLength(256).IsRequired();
            Property(c => c.MetaKeywords).IsMaxLength();
            Property(c => c.MetaDescription).IsMaxLength();
            Property(c => c.CssClass).HasMaxLength(64);
            HasOptional(c => c.Parent).WithMany().Map(fk => fk.MapKey("ParentId")).WillCascadeOnDelete(false);
        }
    }
}
