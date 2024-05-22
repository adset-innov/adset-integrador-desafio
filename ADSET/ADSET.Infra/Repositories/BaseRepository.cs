using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ADSET.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public readonly SqlContext _context;

        public BaseRepository(SqlContext context)
        {
            _context = context;
        }

        public int CountAll()
        {
            return _context.Set<T>()
                .Where(x => x.IsActive)
                .Count();
        }

        public int CountById(Guid id)
        {
            return _context.Set<T>().Where(x => x.Id == id).Count();
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.Add();

            var newEntity = await _context.Set<T>().AddAsync(entity);

            return newEntity.Entity;
        }

        public T Delete(T entity)
        {
            entity.Delete();

            var newEntity = _context.Set<T>().Update(entity);

            return newEntity.Entity;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .Where(x => x.IsActive)
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(x => x.IsActive && x.Id == id);
        }

        public T Update(T entity)
        {
            var newEntity = _context.Set<T>().Update(entity);

            return newEntity.Entity;
        }
    }
}
