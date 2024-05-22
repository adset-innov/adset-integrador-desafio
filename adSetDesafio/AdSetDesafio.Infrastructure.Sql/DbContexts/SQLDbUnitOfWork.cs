using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AdSetDesafio.Infrastructure.Interfaces;

namespace AdSetDesafio.Infrastructure.Sql.DbContexts
{
    public class SQLDbUnitOfWork : IUnitOfWork
    {
        private IDbTransaction _transaction = null;

        public SQLDbContext DbContext { get; }

        public Enum.DbType DbType => Enum.DbType.SqlServer;

        public SQLDbUnitOfWork(IServiceProvider serviceProvider)
        {
            var dbContenxtFactory = serviceProvider.GetRequiredService<IDbContextFactory>();
            var db = dbContenxtFactory.Create(Enum.DbType.SqlServer);
            DbContext = (SQLDbContext)db;
        }
       
        public virtual async Task<bool> Commit()
        {
            var commited = await DbContext.SaveChangesAsync() > 0;
            //notificar via signalR?

            return commited;
        }

        public virtual IDbTransaction GetTransaction()
        {
            if (_transaction == null)
            {
                var con = DbContext;
                _transaction = (IDbTransaction)con.Database.BeginTransaction();
            }

            return _transaction;
        }
    }
}