using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using AdSetDesafio.Infrastructure.Enum;
using AdSetDesafio.Infrastructure.Interfaces;

namespace AdSetDesafio.Infrastructure.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IServiceProvider serviceProvider;

        public UnitOfWorkFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IUnitOfWork Create(DbType dbType)
        {
            var unitOfWorks = serviceProvider.GetServices<IUnitOfWork>();
            var unitOfWork = unitOfWorks.FirstOrDefault(x => x.DbType == dbType);
            
            if (unitOfWork == null)
                throw new ArgumentOutOfRangeException("Tipo de Unit of work nao reconhecido");

            return unitOfWork;
        }
    }
}