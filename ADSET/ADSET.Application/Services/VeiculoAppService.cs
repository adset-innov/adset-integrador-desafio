using ADSET.Application.DTOs.Request;
using ADSET.Application.DTOs.Requests;
using ADSET.Application.DTOs.Response;
using ADSET.Application.DTOs.Responses;
using ADSET.Application.Interfaces;
using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces.Services;
using AutoMapper;

namespace ADSET.Application.Services
{
    public class VeiculoAppService : IVeiculoAppService
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IOpcionalService _opcionalService;
        private readonly IMapper _mapper;

        public VeiculoAppService(IVeiculoService veiculoService, IMapper mapper, IOpcionalService opcionalService)
        {
            _veiculoService = veiculoService;
            _mapper = mapper;
            _opcionalService = opcionalService;
        }

        public async Task<VeiculoResponse> Create(VeiculoRequest request)
        {
            request.Validate();

            if (request.Opcionais != null && request.Opcionais.Count > 0)
            {
                request.Opcionais = request.Opcionais
                    .Distinct()
                    .ToList();

                if (await _opcionalService.VeirfyExistsListId(request.Opcionais) == false)
                    throw new Exception("Erro ao inserir o veiculo");
            }

            var response = await _veiculoService.CreateAsync(
                _mapper.Map<Veiculo>(request), request.Opcionais);

            return _mapper.Map<VeiculoResponse>(response);
        }

        public async Task<List<string>> GetAllColors()
        {
            return await _veiculoService.GetAllColors();
        }

        public VeiculoPaginatedResponse GetByFilter(FilterPaginationRequest request)
        {
            request.Validate();

            var response = _veiculoService.GetListAsync(
                _mapper.Map<Domain.DTOs.Request.FilterPaginationRequest>(request));

            return _mapper.Map<VeiculoPaginatedResponse>(response);
        }
    }
}
