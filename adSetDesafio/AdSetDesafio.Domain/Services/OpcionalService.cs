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
    public sealed class OpcionalService : ServiceEntity<OpcionalService, Opcional, IOpcionalRepository>, IOpcionalService
    {
        private readonly IMapper _mapper;
        private readonly IEnumerable<IAdapterWriter> _writers;
        private readonly IEnumerable<IAdapterReader> _readers;

        public OpcionalService(
            ILogger<OpcionalService> logger,
            IEnumerable<IOpcionalRepository> OpcionalRepository,
            IConfiguration configuration,
            IMapper mapper,
            IEnumerable<IAdapterReader> readers,
            IEnumerable<IAdapterWriter> writers)
            : base( logger, OpcionalRepository, configuration)
        {
            _readers = readers;
            _writers = writers;
            _mapper = mapper;
        }

        public async Task<Opcional> GetAsync(int id)
        {
            Opcional entity = null;
            
            entity = await repositorySql.GetAsync(id);

            return entity;
        }
    }
}