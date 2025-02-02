using Hudson.DB.Extension;
using Hudson.DB.Repository.Interface;
using Hudson.DB.Service;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hudson.DB.Repository
{
    public class ServiceCategoryRepository : IServiceCategoryRepository
    {
        public ServiceCategoryRepository() { }

        public async Task<int> AddAsync(ServiceCategory serviceCategory, CancellationToken cancellationToken)
        {
            await using var db = new AppDbContext();

            await db.ServiceCategories.AddAsync(serviceCategory, cancellationToken);

            return await db.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(ServiceCategory serviceCategory, CancellationToken cancellationToken)
        {
            await using var db = new AppDbContext();

            var category = db.ServiceCategories.FirstOrDefault(c => c.Id == serviceCategory.Id);

            if (category == null)
                return 0;

            var newCategory = new ServiceCategory
            {
                Id = serviceCategory.Id,
                Name = serviceCategory.Name,
                Value = serviceCategory.Value,
                Description = serviceCategory.Description,
                IsDefault = serviceCategory.IsDefault
            };

            db.ServiceCategories.Update(newCategory);
            return await db.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await using var db = new AppDbContext();

            var category = db.ServiceCategories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return 0;

            db.ServiceCategories.Remove(category);
            return await db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ServiceCategory>> QueryAsync(int? id = null, string name = "", CancellationToken cancellationToken = default)
        {
            await using var db = new AppDbContext();
            var categories = db.ServiceCategories.OrderBy(c => c.Id).Include(u => u.ServiceItemWorks.OrderBy(s => s.Id)).AsQueryable();
            if (id.HasValue)
            {
                categories = categories.Where(c => c.Id == id);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                categories = categories.Where(c => string.Equals(c.Name, name, StringComparison.InvariantCultureIgnoreCase));
            }

            var result = categories.AsAsyncEnumerable();

            return await DbExtension.ConvertToEnumerable(result);
        }
    }
}
