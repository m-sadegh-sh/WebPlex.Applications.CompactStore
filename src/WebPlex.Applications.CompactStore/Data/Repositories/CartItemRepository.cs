namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Linq;
    using System.Web.SessionState;
    using WebPlex.Applications.CompactStore.Models;

    public class CartItemRepository : SessionRepositoryBase<CartItemModel>, ICartItemRepository {
        public CartItemRepository(HttpSessionState session) : base(session) {}

        public int GetItemsCount() {
            return GetAll().Sum(ci => ci.Count);
        }
    }
}
