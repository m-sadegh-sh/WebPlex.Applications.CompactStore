namespace WebPlex.Applications.CompactStore.Data.Repositories {
    using System.Collections.Generic;
    using WebPlex.Applications.CompactStore.Models;

    public interface ICategoryRepository : IRepository<CategoryModel> {
        CategoryModel GetBySlug(string slug);
        IEnumerable<CategoryModel> GetParents();
    }
}
