namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Data.Entity;
    using System.Linq;
    using WebPlex.Applications.CompactStore.Models;

    public class OrderComplaintRepository : DbRepositoryBase<OrderComplaintModel>, IOrderComplaintRepository {
        public OrderComplaintRepository(StoreContext context) : base(context) {}

        public OrderComplaintModel GetByOrder(OrderModel order) {
            return GetAll().SingleOrDefault(oc => oc.Order.Id == order.Id);
        }

        protected override IQueryable<OrderComplaintModel> GetIncluded(IQueryable<OrderComplaintModel> queryable) {
            return queryable.Include(oc => oc.Order);
        }
    }
}
