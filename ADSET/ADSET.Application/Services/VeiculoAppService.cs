using ADSET.Application.DTOs.Request;
using ADSET.Application.DTOs.Response;
using ADSET.Application.Interfaces;
using ADSET.Domain.Interfaces.Services;
using AutoMapper;

namespace ADSET.Application.Services
{
    public class VeiculoAppService : IVeiculoAppService
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;

        public VeiculoAppService(IVeiculoService veiculoService, IMapper mapper)
        {
            _veiculoService = veiculoService;
            _mapper = mapper;
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
