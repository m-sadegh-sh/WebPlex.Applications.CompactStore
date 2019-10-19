namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using WebPlex.Applications.CompactStore.Models;

    public interface ICustomerRepository : IRepository<CustomerModel> {
        CustomerModel GetByCellPhone(string cellPhone);
        CustomerModel GetByEmail(string email);
        CustomerModel GetByResetPasswordToken(string resetPasswordToken);
    }
}
