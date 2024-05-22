using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdSetDesafio.Domain.Common.DTOs;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Enums;
using AdSetDesafio.Domain.Common.Interfaces;

namespace AdSetDesafio.Domain.Common.Repositories
{
    public interface IVeiculoRepository : IRepositoryWriterSqlServer<Veiculo>, IRepositoryReader<Veiculo>
    {

        Task<Veiculo> GetAsync(int id);

        Task<(List<Veiculo>, int)> GetAllPaginated(Expression<Func<Veiculo, bool>> predicate, Expression<Func<Veiculo, Veiculo>> selector, FiltroPaginacaoDTO filtroPaginacao);
        
        Task<(List<Veiculo>, int)> GetAllPaginatedAndQueryableAsync(Expression<Func<Veiculo, bool>> search, Expression<Func<Veiculo, bool>> searchKeywords, Expression<Func<Veiculo, bool>> startDate, Expression<Func<Veiculo, bool>> endDate, FiltroPaginacaoConsultarVeiculoDTO filtroPaginacao);
        
        Task<int> GetCount(Expression<Func<Veiculo, bool>> predicate);
    }
}