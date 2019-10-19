using System.Web;
using WebPlex.Applications.CompactStore.AppStart;

[assembly: PreApplicationStartMethod(typeof (DatabaseInitilizerRegisterar), "RegisterInitializer")]

namespace WebPlex.Applications.CompactStore.AppStart {
    using System.Data.Entity;
    using WebPlex.Applications.CompactStore.Data;

    public static class DatabaseInitilizerRegisterar {
        public static void RegisterInitializer() {
            Database.SetInitializer(new StoreInitializer());
        }
    }
}
