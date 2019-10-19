namespace WebPlex.Applications.CompactStore.Data {
    using System.Data.Entity;
    using System.Reflection;

    public sealed class StoreContext : DbContext {
        public StoreContext() {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
