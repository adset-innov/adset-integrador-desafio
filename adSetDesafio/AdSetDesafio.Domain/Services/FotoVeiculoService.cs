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
    public sealed class FotoVeiculoService : ServiceEntity<FotoVeiculoService, FotoVeiculo, IFotoVeiculoRepository>, IFotoVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly IEnumerable<IAdapterWriter> _writers;
        private readonly IEnumerable<IAdapterReader> _readers;

        public FotoVeiculoService(
            ILogger<FotoVeiculoService> logger,
            IEnumerable<IFotoVeiculoRepository> FotoVeiculoRepository,
            IConfiguration configuration,
            IMapper mapper,
            IEnumerable<IAdapterReader> readers,
            IEnumerable<IAdapterWriter> writers)
            : base(logger, FotoVeiculoRepository, configuration)
        {
            _readers = readers;
            _writers = writers;
            _mapper = mapper;
        }

        public async Task<FotoVeiculo> GetAsync(int id)
        {
            FotoVeiculo entity = null;

            entity = await repositorySql.GetAsync(id);

            return entity;
        }

        public async Task<IEnumerable<FotoVeiculo>> GetAllAsync(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                filter = "";

            IEnumerable<FotoVeiculo> data;
            Expression<Func<FotoVeiculo, bool>> query;

            query = x => x.Nome.Contains(filter);

            data = await repositorySql.GetAllAsync(query);

            return data;
        }
    }
}