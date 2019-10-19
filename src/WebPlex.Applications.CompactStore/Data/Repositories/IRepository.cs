namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Linq;

    public interface IRepository<T> {
        IQueryable<T> GetAll();
        bool IsEmpty();
        T GetById(int id);
        void AddOrUpdate(T entity);
        void Delete(T entity);
        void DeleteAll();
        bool SaveChanges();
    }
}
