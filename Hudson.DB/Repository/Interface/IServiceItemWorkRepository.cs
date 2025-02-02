using Hudson.DB.Service;

namespace Hudson.DB.Repository.Interface
{
    public interface IServiceItemWorkRepository
    {
        Task<int> AddAsync(ServiceItemWork serviceItemWork, CancellationToken cancellationToken);

        Task<int> UpdateAsync(ServiceItemWork serviceItemWork, CancellationToken cancellationToken);

        Task<int> DeleteAsync(int id, CancellationToken cancellationToken);

        Task<List<ServiceItemWork>> QueryAsync(int? id = null, int? serviceCategoryId = null, string name = "", bool? isActive = null, CancellationToken cancellationToken = default);
    }
}
