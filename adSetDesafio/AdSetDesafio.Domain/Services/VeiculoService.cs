using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AdSetDesafio.Adapters.XLSX.Models;
using AdSetDesafio.Domain.Common.DTOs;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Enums;
using AdSetDesafio.Domain.Common.Interfaces;
using AdSetDesafio.Domain.Common.Repositories;
using AdSetDesafio.Domain.Services.Interfaces;
using AdSetDesafio.Infrastructure.Exceptions;
using AdSetDesafio.Infrastructure.Extensions;
using AdSetDesafio.Infrastructure.Utilities;
using AdSetDesafio.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdSetDesafio.Domain.Services
{
    public sealed class VeiculoService : ServiceEntity<VeiculoService, Veiculo, IVeiculoRepository>, IVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly IEnumerable<IAdapterWriter> _writers;
        private readonly IEnumerable<IAdapterReader> _readers;

        public VeiculoService(
            ILogger<VeiculoService> logger,
            IEnumerable<IVeiculoRepository> VeiculoRepository,
            IConfiguration configuration,
            IMapper mapper,
            IEnumerable<IAdapterReader> readers,
            IEnumerable<IAdapterWriter> writers)
            : base( logger, VeiculoRepository, configuration)
        {
            _readers = readers;
            _writers = writers;
            _mapper = mapper;
        }

        public async Task<Veiculo> GetAsync(int id)
        {
            Veiculo entity = null;

            entity = await repositorySql.GetAsync(id);

            return entity;
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                filter = "";

            IEnumerable<Veiculo> data;
            Expression<Func<Veiculo, bool>> query;

            query = x => x.Marca.Contains(filter);

            data = await repositorySql.GetAllAsync(query);

            return data;
        }

        public async Task<(IEnumerable<int>, IEnumerable<int>, IEnumerable<int>, IEnumerable<int>, IEnumerable<int>)> GetCountAsync(int filtro)
        {
            List<int> totalizador = new List<int>();
            List<int> coluna1 = new List<int>();
            List<int> coluna2 = new List<int>();
            List<int> coluna3 = new List<int>();
            List<int> coluna4 = new List<int>();

            DateTime dataAtual = DateTime.Now;
            DateTime dataBase = DateTime.Now;

            if(filtro >= 0)
            {
                for (int i = 1; i <= 12; i++)
                {
                    //preencher contadores
                }
            }
            else
            {
                for(int i = 4; i >= 0; i--)
                {
                    dataAtual = dataBase.AddYears(-i);

                    //definir valor fantasia

                }
            }

            var cadastradoCount = await repositorySql.GetCount(x => x.Id == 1);
            totalizador.Add(cadastradoCount);
            var comFotoCount = await repositorySql.GetCount(x => x.Id == 2);
            totalizador.Add(comFotoCount);
            var semFotoCount = await repositorySql.GetCount(x => x.Id == 3);
            totalizador.Add(semFotoCount);
            var ICarrosWebMotorsCount = await repositorySql.GetCount(x => x.Id == 4);
            totalizador.Add(ICarrosWebMotorsCount);

            return (totalizador, coluna1, coluna2, coluna3, coluna4);
        }

        public async Task<PaginacaoDTO<Veiculo>> GetAllPaginated(FiltroPaginacaoDTO filtroPaginacao)
        {
            if (string.IsNullOrEmpty(filtroPaginacao.Filtro))
                filtroPaginacao.Filtro = "";

            PaginacaoDTO<Veiculo> resultPaginacao = null;
            Expression<Func<Veiculo, bool>> query = x => x.Modelo.Contains(filtroPaginacao.Filtro);
            Expression<Func<Veiculo, Veiculo>> selector = x => new Veiculo { Id = x.Id };

            (List<Veiculo> dados, int total) = await repositorySql.GetAllPaginated(query, selector, filtroPaginacao);

            if (dados.Any())
                resultPaginacao = new PaginacaoDTO<Veiculo>
                {
                    Dados = dados,
                    Total = total,
                    Pagina = filtroPaginacao.Pagina,
                    QuantidadePorPagina = filtroPaginacao.QuantidadePorPagina
                };

            return resultPaginacao;
        }

        public async Task<PaginacaoDTO<Veiculo>> GetAllPaginatedAndQueryableAsync(FiltroPaginacaoConsultarVeiculoDTO filtroPaginacao)
        {
            PaginacaoDTO<Veiculo> resultPaginacao = null;

            Expression<Func<Veiculo, bool>> search = p =>
                p.Marca.Contains(filtroPaginacao.Search);

            Expression<Func<Veiculo, bool>> searchKeywords;
            if (filtroPaginacao.SearchStatusId != null && filtroPaginacao.SearchStatusId.Contains(-1))
            {
                searchKeywords = p => filtroPaginacao.SearchStatusId.Contains(p.Id);
            }
            else
            {
                searchKeywords = p => filtroPaginacao.SearchStatusId.Contains(p.Id);
            }

            if(filtroPaginacao.StartDate.Date == DateTime.MinValue && filtroPaginacao.EndDate.Date == DateTime.MinValue)
            {
                filtroPaginacao.StartDate = DateTime.Now.AddYears(-1);
                filtroPaginacao.EndDate = DateTime.Now;
            }

            Expression<Func<Veiculo, bool>> startDate = p => p.Ano >= filtroPaginacao.StartDate.Date.Year;

            Expression<Func<Veiculo, bool>> endDate = p => p.Ano <= filtroPaginacao.EndDate.Date.Year;

            (List<Veiculo> dados, int total) = await repositorySql.GetAllPaginatedAndQueryableAsync(search, searchKeywords, startDate, endDate, filtroPaginacao);

            resultPaginacao = new PaginacaoDTO<Veiculo>
            {
                Dados = dados,
                Total = total,
                Pagina = filtroPaginacao.Pagina,
                QuantidadePorPagina = filtroPaginacao.QuantidadePorPagina
            };

            return resultPaginacao;
        }

        public async Task SaveAsync(Veiculo entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.Marca))
                entity.Marca = entity.Marca.Replace("_", "");

            entity.Id = await repositorySql.SaveAsync(entity);
        }

        public async Task UpdateAsync(Veiculo entity)
        {
            var entitySave = await repositorySql.GetAsync(entity.Id);
            if (entitySave == default)
                throw HandledError.InvalidOperation("Veiculo não encontrado.");


            if (entity.Marca.HasValue())
                entity.Marca = entity.Marca.Replace("_", "");

            //so deve alterar se tiver um novo valor. 
            if (entity.Modelo.HasValue())
                entitySave.Modelo = entity.Modelo;

            entitySave.Ano = entity.Ano;

            await repositorySql.UpdateAsync(entitySave);
            //fazer update de fotos depois await repositorySql.UpdateFotosVeiculoAsync(entity.Id, entity.FotoVeiculo);
        }

        public async Task DeleteAsync(int id)
        {
            await repositorySql.DeleteAsync(id);
        }

        public async Task<string> ExportarVeiculos(IEnumerable<VeiculoExport> Veiculos, string fileName)
        {
            if (Veiculos == null)
                throw new Exception("A lista não foi inicializada.");

            if (!Veiculos.Any())
                Veiculos = new List<VeiculoExport> { new VeiculoExport() };

            foreach (var item in Veiculos)
                if (string.IsNullOrWhiteSpace(item.Marca))
                    item.Marca = "";

            var fullName = Path.Combine("~/wwwroot/lib/", "uploads", fileName);
            var writer = SelectAdapterWriter(fullName);

            var directory = Path.GetDirectoryName(fullName);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return await writer.WriteDataAsync(Veiculos.ToList(), fullName);
        }

        #region Métodos Privados

        private IAdapterWriter SelectAdapterWriter(string path)
        {
            return _writers.FirstOrDefault(x => x.GetType().Name.ToUpper() == Path.GetExtension(path).ToUpper().Replace(".", "") + "WRITER");
        }

        #endregion
    }
}