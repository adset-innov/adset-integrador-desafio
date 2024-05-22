using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Interfaces;

namespace AdSetDesafio.Domain.Handlers
{
    public abstract class CommandHandlerBase<TEntity, TServiceReader, TLogger>
        where TEntity : Entity, IEntity
        where TServiceReader : IServiceReader<TEntity>
    {
        protected readonly ILogger<TLogger> Logger;
        protected readonly IServiceReader<TEntity> Service;
        protected readonly IMapper Mapper;

        public CommandHandlerBase(ILogger<TLogger> logger, IServiceReader<TEntity> service, IMapper mapper, IConfiguration configuration)
        {
            Logger = logger;
            Service = service;
            Mapper = mapper;
        }
    }
}