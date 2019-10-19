namespace WebPlex.Applications.CompactStore.Data {
    using System.Data.Entity;

    public sealed class StoreInitializer : MigrateDatabaseToLatestVersion<StoreContext, StoreMigrationsConfiguration> {}
}
