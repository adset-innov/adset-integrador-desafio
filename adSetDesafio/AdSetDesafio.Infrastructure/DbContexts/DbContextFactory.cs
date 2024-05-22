using System;
using System.Linq;
using AdSetDesafio.Infrastructure.Enum;
using AdSetDesafio.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdSetDesafio.Infrastructure.DbContexts
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IServiceProvider serviceProvider;

        public DbContextFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IDbContext Create(DbType dbType)
        {
            var dbContexts = serviceProvider.GetServices<IDbContext>();
            var dbContext = dbContexts.FirstOrDefault(x => x.DbType == dbType);
            
            if (dbContext == null)
                throw new ArgumentOutOfRangeException("Tipo de banco de dados nao reconhecido");

            return dbContext;
        }
    }
}