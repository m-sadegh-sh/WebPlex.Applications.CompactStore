namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Data.Entity;
    using System.Linq;
    using WebPlex.Applications.CompactStore.Models;

    public class OrderLineRepository : DbRepositoryBase<OrderLineModel>, IOrderLineRepository {
        public OrderLineRepository(StoreContext context) : base(context) {}

        protected override IQueryable<OrderLineModel> GetIncluded(IQueryable<OrderLineModel> queryable) {
            return queryable.Include(ol => ol.Order).Include(ol => ol.Product);
        }
    }
}
