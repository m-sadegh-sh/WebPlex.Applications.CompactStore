namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.SessionState;

    public abstract class SessionRepositoryBase<T> : IRepository<T> where T : class {
        private static readonly string _sessionKey = string.Format("${0}$", typeof (T).AssemblyQualifiedName);
        private readonly HttpSessionState _session;
        private IList<T> _table;

        protected SessionRepositoryBase(HttpSessionState session) {
            _session = session;
        }

        private IList<T> GetTable() {
            if (_table == null) {
                _table = _session[_sessionKey] as IList<T>;

                if (_table == null)
                    _table = new List<T>();
            }

            return _table;
        }

        public IQueryable<T> GetAll() {
            return GetTable().AsQueryable();
        }

        public bool IsEmpty() {
            return !GetAll().Any();
        }

        public T GetById(int id) {
            return GetAll().SingleOrDefault(e => e.GetHashCode() == id);
        }

        public void AddOrUpdate(T entity) {
            var idx = GetTable().IndexOf(entity);

            if (idx >= 0)
                GetTable()[idx] = entity;
            else
                GetTable().Add(entity);
        }

        public void Delete(T entity) {
            GetTable().Remove(entity);
        }

        public void DeleteAll() {
            var all = GetTable().ToList();

            foreach (var entity in all)
                GetTable().Remove(entity);
        }

        public bool SaveChanges() {
            _session[_sessionKey] = _table;
            return true;
        }
    }
}
