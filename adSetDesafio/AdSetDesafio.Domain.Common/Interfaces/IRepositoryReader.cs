using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdSetDesafio.Domain.Common.Entities;

namespace AdSetDesafio.Domain.Common.Interfaces
{
    public interface IRepositoryReader<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> GetAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}