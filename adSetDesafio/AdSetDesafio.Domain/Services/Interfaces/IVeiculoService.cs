using System.Threading.Tasks;
using System.Collections.Generic;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Interfaces;
using AdSetDesafio.Domain.Common.DTOs;
using AdSetDesafio.Adapters.XLSX.Models;
using AdSetDesafio.Infrastructure.ViewModel;
using System;
using AdSetDesafio.Domain.Common.Enums;

namespace AdSetDesafio.Domain.Services.Interfaces
{
    public interface IVeiculoService : IServiceReader<Veiculo>
    {
        Task<Veiculo> GetAsync(int id);

        Task<IEnumerable<Veiculo>> GetAllAsync(string filter);

        Task<(IEnumerable<int>, IEnumerable<int>, IEnumerable<int>, IEnumerable<int>, IEnumerable<int>)> GetCountAsync(int filtro);

        Task<PaginacaoDTO<Veiculo>> GetAllPaginated(FiltroPaginacaoDTO filtroPaginacao);

        Task<PaginacaoDTO<Veiculo>> GetAllPaginatedAndQueryableAsync(FiltroPaginacaoConsultarVeiculoDTO filtroPaginacao);

        Task SaveAsync(Veiculo entity);

        Task UpdateAsync(Veiculo entity);

        Task DeleteAsync(int id);

        Task<string> ExportarVeiculos(IEnumerable<VeiculoExport> Veiculos, string fileName);
    }
}