using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdSetDesafio.Domain.Common.DTOs;
using AdSetDesafio.Domain.Common.Enums;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Repositories;
using System.Diagnostics;
using AdSetDesafio.Infrastructure.Extensions;

namespace AdSetDesafio.Infrastructure.Sql.Repositories
{
    public sealed class FotoVeiculoRepository : RepositoryBase<FotoVeiculo, IFotoVeiculoRepository>, IFotoVeiculoRepository
    {
        public string GetDbType()
        {
            return Enum.DbType.SqlServer.ToString();
        }

        public FotoVeiculoRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task SaveAsync(ICollection<FotoVeiculo> FotosVeiculo)
        {
            await AddItemsAsync(FotosVeiculo);
        }

        //avaliar estrategia de update
        //public async Task UpdateAsync(int idVeiculo, ICollection<FotoVeiculo> FotosVeiculo)
        //{
        //    await DeleteItemsAsync(await GetFotosVeiculoToDeleteAsync(idVeiculo));
        //    await AddItemsAsync(FotosVeiculo);
        //}
        //public async Task UpdateAsync(FotoVeiculo entity)
        //{
        //    var uow = GetUnitOfWork();
        //    var db = uow.DbContext;

        //    db.Entry(entity).State = EntityState.Modified;
        //    await uow.Commit();
        //}

        public async Task<IEnumerable<FotoVeiculo>> GetAllAsync(Expression<Func<FotoVeiculo, bool>> predicate)
        {
            var db = GetDbContext();
            var data = await db.FotosVeiculos
                .AsNoTracking()
                .ToListAsync();

            return data;
        }

        public Task<int> SaveAsync(FotoVeiculo entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FotoVeiculo entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FotoVeiculo> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}