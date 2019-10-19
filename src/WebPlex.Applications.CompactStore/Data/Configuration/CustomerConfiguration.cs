namespace WebPlex.Applications.CompactStore.Data.Configuration {
    using WebPlex.Applications.CompactStore.Models;

    public sealed class CustomerConfiguration : EntityConfigurationBase<CustomerModel> {
        public CustomerConfiguration() {
            ToTable("Customers");
            Property(c => c.CellPhone).HasMaxLength(24).IsRequired();
            Property(c => c.SecuredSalt).HasMaxLength(128).IsRequired();
            Property(c => c.SecuredPassword).HasMaxLength(128).IsRequired();
            Property(c => c.FirstName).HasMaxLength(64).IsRequired();
            Property(c => c.LastName).HasMaxLength(64).IsRequired();
            Property(c => c.Email).HasMaxLength(128).IsRequired();
            Property(c => c.Gender);
            Property(c => c.IsAdmin);
            Property(c => c.InvalidCredentialsAttempt);
            Property(c => c.LockedOutDateUtc);
            Property(c => c.ResetPasswordToken);
            Property(c => c.ResetPasswordRequestedDateUtc);
            Ignore(c => c.ResetPasswordExpiresDateUtc);
        }
    }
}
