namespace WebPlex.Applications.CompactStore.Data.Configuration {
    using WebPlex.Applications.CompactStore.Models;

    public sealed class OrderConfiguration : EntityConfigurationBase<OrderModel> {
        public OrderConfiguration() {
            ToTable("Orders");
            Property(o => o.AccessToken).HasMaxLength(8);
            HasRequired(o => o.Customer).WithMany().Map(fk => fk.MapKey("CustomerId")).WillCascadeOnDelete(false);
            Property(o => o.SubmitDateUtc);
            Property(o => o.Status);
            Property(o => o.TotalPrice);
            Property(o => o.IpAddress).IsRequired();
        }
    }
}
