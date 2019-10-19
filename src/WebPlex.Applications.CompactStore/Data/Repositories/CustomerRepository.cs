namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Linq;
    using WebPlex.Applications.CompactStore.Models;

    public class CustomerRepository : DbRepositoryBase<CustomerModel>, ICustomerRepository {
        public CustomerRepository(StoreContext context) : base(context) {}

        public CustomerModel GetByCellPhone(string cellPhone) {
            return GetAll().FirstOrDefault(c => c.CellPhone == cellPhone);
        }

        public CustomerModel GetByEmail(string email) {
            return GetAll().FirstOrDefault(c => c.Email == email);
        }

        public CustomerModel GetByResetPasswordToken(string resetPasswordToken) {
            return GetAll().FirstOrDefault(c => c.ResetPasswordToken == resetPasswordToken);;
        }

        protected override IQueryable<CustomerModel> GetIncluded(IQueryable<CustomerModel> queryable) {
            return queryable;
        }
    }
}
