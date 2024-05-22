using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AdSetDesafio.Domain.Commands.Veiculo;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Enums;
using AdSetDesafio.Domain.Services.Interfaces;
using AdSetDesafio.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdSetDesafio.Domain.Handlers
{
    public class VeiculoCommandHandler : CommandHandlerBase<Veiculo, IVeiculoService, VeiculoCommandHandler>,
        IRequestHandler<VeiculoCommandCreate, ValidationResult>,
        IRequestHandler<VeiculoCommandUpdate, ValidationResult>,
        IRequestHandler<VeiculoCommandDelete, ValidationResult>
    {

        public VeiculoCommandHandler(
            ILogger<VeiculoCommandHandler> logger,
            IVeiculoService service,
            IMapper mapper,
            IConfiguration configuration)
            : base(logger, service, mapper, configuration)
        {

        }

        public async Task<ValidationResult> Handle(VeiculoCommandCreate request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Command: {nameof(VeiculoCommandCreate)}, CorrelationId: {request.AggregateId}");

            if (request.IsValid())
            {

                var service = (IVeiculoService)Service;
                var entity = Mapper.Map<VeiculoCommandCreate, Veiculo>(request);
                await service.SaveAsync(entity);
                request.Id = entity.Id;

            }

            return request.ValidationResult;
        }

        public async Task<ValidationResult> Handle(VeiculoCommandUpdate request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Command: {nameof(VeiculoCommandUpdate)}, CorrelationId: {request.AggregateId}");

            if (request.IsValid())
            {
                var service = (IVeiculoService)Service;
                var entity = Mapper.Map<VeiculoCommandUpdate, Veiculo>(request);
               
                await service.UpdateAsync(entity);

            }

            return request.ValidationResult;
        }

        public async Task<ValidationResult> Handle(VeiculoCommandDelete request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Command: {nameof(VeiculoCommandDelete)}, CorrelationId: {request.AggregateId}");

            if (request.IsValid())
            {
                var service = (IVeiculoService)Service;
                await service.DeleteAsync(request.Id);
            }

            return request.ValidationResult;
        }
    }
}