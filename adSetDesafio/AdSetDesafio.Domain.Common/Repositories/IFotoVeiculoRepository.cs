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
    public interface IFotoVeiculoRepository : IRepositoryWriterSqlServer<FotoVeiculo>, IRepositoryReader<FotoVeiculo>
    {
        Task SaveAsync(ICollection<FotoVeiculo> FotosVeiculo);
    }
}