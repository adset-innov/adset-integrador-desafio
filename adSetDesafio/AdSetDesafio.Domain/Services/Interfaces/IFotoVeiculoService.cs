﻿using System.Threading.Tasks;
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
    public interface IFotoVeiculoService : IServiceReader<FotoVeiculo>
    {
        Task<FotoVeiculo> GetAsync(int id);

        Task<IEnumerable<FotoVeiculo>> GetAllAsync(string filter);

    }
}