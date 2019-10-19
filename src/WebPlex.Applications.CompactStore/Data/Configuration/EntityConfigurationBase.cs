namespace WebPlex.Applications.CompactStore.Data.Configuration {
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using WebPlex.Applications.CompactStore.Models;

    public abstract class EntityConfigurationBase<T> : EntityTypeConfiguration<T> where T : DbModelBase {
        public EntityConfigurationBase() {
            HasKey(e => e.Id);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
