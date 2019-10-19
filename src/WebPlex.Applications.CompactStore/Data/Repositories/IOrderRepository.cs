namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Collections.Generic;
    using WebPlex.Applications.CompactStore.Models;

    public interface IOrderRepository : IRepository<OrderModel> {
        IEnumerable<OrderModel> GetByCustomer(CustomerModel customer, ref int? page, ref int? size, out int totalItemsCount);
        int GetCountByCustomer(CustomerModel customer);
        OrderModel GetByAccessToken(string accessToken);
        bool IsTrustedCustomer(CustomerModel customer, OrderModel order);
    }
}
