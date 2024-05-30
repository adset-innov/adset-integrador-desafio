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
    public sealed class VeiculoRepository : RepositoryBase<Veiculo, IVeiculoRepository>, IVeiculoRepository
    {
        public string GetDbType()
        {
            return Enum.DbType.SqlServer.ToString();
        }

        public VeiculoRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<int> SaveAsync(Veiculo entity)
        {
            var uow = GetUnitOfWork();
            var db = uow.DbContext;
            var obj = await db.Veiculos.AddAsync(entity);
            await uow.Commit();

            return obj.Entity.Id;
        }

        public async Task UpdateAsync(Veiculo entity)
        {
            var uow = GetUnitOfWork();
            var db = uow.DbContext;

            db.Entry(entity).State = EntityState.Modified;
            await uow.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            var uow = GetUnitOfWork();
            var db = uow.DbContext;
            var result = await db.Veiculos.FindAsync(id);

            if (result is not null)
            {
                db.Veiculos.Remove(result);
                await uow.Commit();
            }
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync(Expression<Func<Veiculo, bool>> predicate)
        {
            var db = GetDbContext();
            var data = await db.Veiculos
                .AsNoTracking()
                .ToListAsync();

            return data;
        }

        public async Task<int> GetCount(Expression<Func<Veiculo, bool>> predicate)
        {
            var db = GetDbContext();
            var data = await db.Veiculos
                .AsNoTracking()
                .CountAsync();

            return data;
        }

        public async Task<(List<Veiculo>, int)> GetAllPaginated(Expression<Func<Veiculo, bool>> predicate, Expression<Func<Veiculo, Veiculo>> selector, FiltroPaginacaoDTO filtroPaginacao)
        {
            var consulta = GetAllPaginatedDefault(predicate, selector);

            return (await consulta?
                .Skip((filtroPaginacao.Pagina - 1) * filtroPaginacao.QuantidadePorPagina)
                .Take(filtroPaginacao.QuantidadePorPagina)
                .ToListAsync(),
                await consulta.CountAsync());
        }

        public async Task<(List<Veiculo>, int)> GetAllPaginatedAndQueryableAsync(Expression<Func<Veiculo, bool>> placa, Expression<Func<Veiculo, bool>> marca, Expression<Func<Veiculo, bool>> modelo, Expression<Func<Veiculo, bool>> opcional, Expression<Func<Veiculo, bool>> anoMin, Expression<Func<Veiculo, bool>> anoMax, Expression<Func<Veiculo, bool>> preco, Expression<Func<Veiculo, bool>> fotos, Expression<Func<Veiculo, bool>> cor, FiltroPaginacaoConsultarVeiculoDTO filtroPaginacao)
        {
            var db = GetDbContext();

            var veiculos = db
                .Veiculos
                .AsNoTracking();

            IQueryable<Veiculo> consulta = veiculos;

            if (!string.IsNullOrWhiteSpace(filtroPaginacao.Placa))
                consulta = consulta.Where(placa);

            if (!string.IsNullOrWhiteSpace(filtroPaginacao.Marca))
                consulta = consulta.Where(marca);

            if (!string.IsNullOrWhiteSpace(filtroPaginacao.Modelo))
                consulta = consulta.Where(modelo);

            if (!string.IsNullOrWhiteSpace(filtroPaginacao.Opcional))
                consulta = consulta.Where(opcional);

            if (filtroPaginacao.AnoMin != null)
                consulta = consulta.Where(anoMin);

            if (filtroPaginacao.AnoMax != null)
                consulta = consulta.Where(anoMax);

            if (filtroPaginacao.Preco != null)
                consulta = consulta.Where(preco);

            if (filtroPaginacao.Fotos != null)
                consulta = consulta.Where(fotos);

            if (!string.IsNullOrWhiteSpace(filtroPaginacao.Cor))
                consulta = consulta.Where(cor);

            var VeiculoCount = await consulta.CountAsync();

            if (filtroPaginacao != default)
            {
                consulta = consulta
                    .Skip((filtroPaginacao.Pagina - 1) * filtroPaginacao.QuantidadePorPagina)
                    .Take(filtroPaginacao.QuantidadePorPagina);
            }

            var listVeiculo = await consulta?
                    .ToListAsync();

            return (veiculos.ToList(), veiculos.Count());
        }

        private IQueryable<Veiculo> GetAllPaginatedDefault(Expression<Func<Veiculo, bool>> predicate, Expression<Func<Veiculo, Veiculo>> selector)
        {
            var db = GetDbContext();

            return db.Veiculos
                .AsNoTracking()
                .Select(selector);
        }

        //public async Task SaveAnexo(FotoVeiculo FotosVeiculo)
        //{
        //    var uow = GetUnitOfWork();
        //    var db = uow.DbContext;
        //    await db.FotosVeiculos.AddAsync(FotosVeiculo);
        //    await uow.Commit();
        //}

        public Task<Veiculo> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}