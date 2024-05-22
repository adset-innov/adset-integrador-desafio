using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Interfaces;
using AdSetDesafio.Infrastructure.Interfaces;
using AdSetDesafio.Infrastructure.Extensions;
using AdSetDesafio.Infrastructure.Sql.DbContexts;

namespace AdSetDesafio.Infrastructure.Sql.Repositories
{
    public abstract class RepositoryBase<TEntity, TRepository>
        where TEntity : class, IAggregateRoot
        where TRepository : IRepositoryWriterSqlServer<TEntity>, IRepositoryReader<TEntity>
    {
        private readonly IServiceProvider serviceProvider;

        public RepositoryBase(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected SQLDbUnitOfWork GetUnitOfWork()
        {
            var iowFactory = serviceProvider.GetRequiredService<IUnitOfWorkFactory>();
            return (SQLDbUnitOfWork)iowFactory.Create(Enum.DbType.SqlServer);
        }

        protected SQLDbContext GetDbContext()
        {
            return (SQLDbContext)serviceProvider.GetRequiredService<IDbContextFactory>().Create(Enum.DbType.SqlServer);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var db = GetDbContext();
            var data = await db.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);

            return data is not null;
        }

        protected async Task DeleteAsync<TEntitySend>(TEntitySend entity)
            where TEntitySend : Entity
        {
            var uow = GetUnitOfWork();

            var db = uow.DbContext;
            db.Entry(entity).State = EntityState.Deleted;

            await uow.Commit();
        }

        protected async Task AddItemsAsync<TEntitySend>(IEnumerable<TEntitySend> entities)
            where TEntitySend : Entity
        {
            if (!entities.HasValue())
                return;

            foreach (var entity in entities)
                await AddAsync(entity);
        }

        protected async Task<int> AddAsync<TEntitySend>(TEntitySend entity)
            where TEntitySend : Entity
        {
            var uow = GetUnitOfWork();
            var db = uow.DbContext;
            var obj = await db.Set<TEntitySend>().AddAsync(entity);
            await uow.Commit();

            return obj.Entity.Id;
        }
    }
}