namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using WebPlex.Applications.CompactStore.Models;

    public class CategoryRepository : DbRepositoryBase<CategoryModel>, ICategoryRepository {
        public CategoryRepository(StoreContext context) : base(context) {}

        public override IQueryable<CategoryModel> GetAll() {
            return base.GetAll().OrderBy(c => c.DisplayOrder);
        }

        protected override IQueryable<CategoryModel> GetIncluded(IQueryable<CategoryModel> queryable) {
            return queryable.Include(c => c.Parent);
        }

        public CategoryModel GetBySlug(string slug) {
            return GetAll().SingleOrDefault(c => string.Compare(c.Slug, slug, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public IEnumerable<CategoryModel> GetParents() {
            return GetAll().Where(c => c.Parent == null);
        }
    }
}
