namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using WebPlex.Applications.CompactStore.Configuration;
    using WebPlex.Applications.CompactStore.Models;

    public class OrderRepository : DbRepositoryBase<OrderModel>, IOrderRepository {
        public OrderRepository(StoreContext context) : base(context) {}

        public IEnumerable<OrderModel> GetByCustomer(CustomerModel customer, ref int? page, ref int? size, out int totalItemsCount) {
            page = page.GetValueOrDefault(1);
            size = size.GetValueOrDefault(AppConfiguration.Current.DefaultPageSize);

            var orders = GetAll().Where(o => o.Customer.Id == customer.Id);

            orders = orders.OrderByDescending(o => o.SubmitDateUtc);

            totalItemsCount = orders.Count();

            orders = orders.Skip(((int) page - 1)*(int) size).Take((int) size);

            return orders.ToList();
        }

        public int GetCountByCustomer(CustomerModel customer) {
            return GetAll().Count(o => o.Customer.Id == customer.Id);
        }

        public OrderModel GetByAccessToken(string accessToken) {
            return GetAll().SingleOrDefault(o => o.AccessToken == accessToken);
        }

        public bool IsTrustedCustomer(CustomerModel customer, OrderModel order) {
            return GetAll().Any(o => o.Customer.Id == customer.Id && o.Id != order.Id && o.Status == OrderStatus.Completed);
        }

        protected override IQueryable<OrderModel> GetIncluded(IQueryable<OrderModel> queryable) {
            return queryable.Include(o => o.Customer);
        }

        public override void AddOrUpdate(OrderModel order) {
            AttachAsUnchanged(order.Customer);

            base.AddOrUpdate(order);
        }
    }
}
