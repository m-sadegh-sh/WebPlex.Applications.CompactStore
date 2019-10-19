namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using WebPlex.Applications.CompactStore.Models;

    public interface ICartItemRepository : IRepository<CartItemModel> {
        int GetItemsCount();
    }
}
