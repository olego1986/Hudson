using Hudson.DB.Repository.Interface;
using Hudson.DB.Service;
using Microsoft.EntityFrameworkCore;

namespace Hudson.DB.Repository
{
    public class ServiceItemWorkRepository : IServiceItemWorkRepository
    {
        public ServiceItemWorkRepository() { }

        public async Task<int> AddAsync(ServiceItemWork serviceItemWork, CancellationToken cancellationToken)
        {
            await using var db = new AppDbContext();

            await db.ServiceItemWorks.AddAsync(serviceItemWork, cancellationToken);

            return await db.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(ServiceItemWork serviceItemWork, CancellationToken cancellationToken)
        {
            await using var db = new AppDbContext();

            var itemWork = db.ServiceItemWorks.FirstOrDefault(c => c.Id == serviceItemWork.Id);

            if (itemWork == null)
                return 0;

            var newServiceItemWork = new ServiceItemWork()
            {
                Id = itemWork.Id,
                Name = itemWork.Name,
                Value = itemWork.Value,
                Description = itemWork.Description,
                ServiceCategoryId = itemWork.ServiceCategoryId
            };

            db.ServiceItemWorks.Update(newServiceItemWork);
            return await db.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await using var db = new AppDbContext();

            var serviceItemWork = db.ServiceItemWorks.FirstOrDefault(c => c.Id == id);

            if (serviceItemWork == null)
                return 0;

            db.ServiceItemWorks.Remove(serviceItemWork);
            return await db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ServiceItemWork>> QueryAsync(int? id = null, int? serviceCategoryId = null, string name = "", bool? isActive = null, CancellationToken cancellationToken = default)
        {
            await using var db = new AppDbContext();

            var serviceItemWorks = db.ServiceItemWorks.AsQueryable();
            if (id.HasValue)
            {
                serviceItemWorks = serviceItemWorks.Where(c => c.Id == id);
            }

            if (serviceCategoryId.HasValue)
            {
                serviceItemWorks = serviceItemWorks.Where(c => c.ServiceCategoryId == serviceCategoryId);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                serviceItemWorks = serviceItemWorks.Where(c => string.Equals(c.Name, name, StringComparison.InvariantCultureIgnoreCase));
            }

            if (isActive.HasValue)
            {
                serviceItemWorks = serviceItemWorks.Where(c => c.IsActive == isActive);
            }

            return await serviceItemWorks.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
