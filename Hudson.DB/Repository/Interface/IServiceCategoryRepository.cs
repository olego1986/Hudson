using Hudson.DB.Service;

namespace Hudson.DB.Repository.Interface
{
    public interface IServiceCategoryRepository
    {
        Task<int> AddAsync(ServiceCategory serviceCategory, CancellationToken cancellationToken);

        Task<int> UpdateAsync(ServiceCategory serviceCategory, CancellationToken cancellationToken);

        Task<int> DeleteAsync(int id, CancellationToken cancellationToken);

        Task<List<ServiceCategory>> QueryAsync(int? id = null, string name = "", CancellationToken cancellationToken = default);
    }
}
