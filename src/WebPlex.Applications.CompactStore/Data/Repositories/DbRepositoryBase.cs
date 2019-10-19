namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using WebPlex.Applications.CompactStore.Logging;
    using WebPlex.Applications.CompactStore.Models;

    public abstract class DbRepositoryBase<T> : IRepository<T> where T : DbModelBase {
        private readonly StoreContext _context;

        protected DbRepositoryBase(StoreContext context) {
            _context = context;
        }

        private IDbSet<T> GetTable() {
            return _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll() {
            return GetIncluded(GetTable().AsQueryable());
        }

        protected abstract IQueryable<T> GetIncluded(IQueryable<T> queryable);

        public bool IsEmpty() {
            return !GetAll().Any();
        }

        public T GetById(int id) {
            return GetAll().SingleOrDefault(e => e.Id == id);
        }

        public virtual void AddOrUpdate(T entity) {
            GetTable().AddOrUpdate(entity);
        }

        public void Delete(T entity) {
            GetTable().Remove(entity);
        }

        public void DeleteAll() {
            foreach (var entity in GetTable())
                GetTable().Remove(entity);
        }

        public bool SaveChanges() {
            try {
                _context.SaveChanges();
                return true;
            } catch (DbEntityValidationException exception) {
                throw new Exception(ExceptionSerializationHelpers.ToFriendlyString(exception), exception);
            } catch (Exception exception) {
                //LogHelpers.Write(exception);
                throw;
            }

            return false;
        }

        protected void AttachAsUnchanged<TOther>(TOther entity) where TOther : DbModelBase {
            if (_context.Entry(entity).State != EntityState.Unchanged)
                _context.Entry(entity).State = EntityState.Unchanged;
        }
    }
}
