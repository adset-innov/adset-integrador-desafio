using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        T Delete(T entity);
        int CountById(Guid id);
        int CountAll();
    }
}
