using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Interfaces;
using AdSetDesafio.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdSetDesafio.Domain.Services
{
    public abstract class ServiceEntity<TService, TEntity, TRepository>
        where TEntity : Entity, IAggregateRoot
        where TService : IServiceReader<TEntity>
        where TRepository : IRepositoryReader<TEntity>, IRepositoryWriter
    {
        protected readonly ILogger<TService> logger;
        protected readonly TRepository repositorySql;
        protected readonly IConfiguration configuration;
        protected virtual bool UseCaching { get; }

        protected ServiceEntity( ILogger<TService> logger, IEnumerable<TRepository> repositories, IConfiguration configuration)
        {
            this.logger = logger;
            this.repositorySql = repositories.FirstOrDefault(x => x.GetDbType() == "SqlServer");
            this.configuration = configuration;
        }
    }
}