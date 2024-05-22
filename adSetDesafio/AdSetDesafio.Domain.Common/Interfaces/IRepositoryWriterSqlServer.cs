using System.Threading.Tasks;

namespace AdSetDesafio.Domain.Common.Interfaces
{
    public interface IRepositoryWriterSqlServer<TEntity> : IRepositoryWriter
    {
        Task<int> SaveAsync(TEntity entity);
        
        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}