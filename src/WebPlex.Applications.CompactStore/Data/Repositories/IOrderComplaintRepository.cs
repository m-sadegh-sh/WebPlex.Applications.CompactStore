namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using WebPlex.Applications.CompactStore.Models;

    public interface IOrderComplaintRepository : IRepository<OrderComplaintModel> {
        OrderComplaintModel GetByOrder(OrderModel order);
    }
}
