namespace WebPlex.Applications.CompactStore.Data.Configuration {
    using WebPlex.Applications.CompactStore.Models;

    public sealed class OrderLineConfiguration : EntityConfigurationBase<OrderLineModel> {
        public OrderLineConfiguration() {
            ToTable("OrderLines");
            HasRequired(ol => ol.Order).WithMany().Map(fk => fk.MapKey("OrderId")).WillCascadeOnDelete(false);
            HasRequired(ol => ol.Product).WithMany().Map(fk => fk.MapKey("ProductId")).WillCascadeOnDelete(false);
            Property(ol => ol.Count);
        }
    }
}
