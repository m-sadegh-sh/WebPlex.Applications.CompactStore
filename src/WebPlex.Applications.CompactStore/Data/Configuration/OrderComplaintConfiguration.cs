namespace WebPlex.Applications.CompactStore.Data.Configuration {
    using WebPlex.Applications.CompactStore.Models;

    public sealed class OrderComplaintConfiguration : EntityConfigurationBase<OrderComplaintModel> {
        public OrderComplaintConfiguration() {
            ToTable("OrderComplaints");
            HasRequired(oc => oc.Order).WithMany().Map(fk => fk.MapKey("OrderId")).WillCascadeOnDelete(false);
            Property(oc => oc.SubmitDateUtc);
            Property(oc => oc.Message).IsMaxLength().IsRequired();
            Property(oc => oc.Priority);
            Property(oc => oc.Status);
            Property(oc => oc.CheckDateUtc);
            Property(oc => oc.Reply).IsMaxLength();
        }
    }
}
