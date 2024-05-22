using ADSET.Application.DTOs.Responses;
using ADSET.Application.Interfaces;
using ADSET.Domain.Interfaces.Services;
using AutoMapper;

namespace ADSET.Application.Services
{
    public class MarcaAppService : IMarcaAppService
    {
        public readonly IMarcaService _marcaService;
        public readonly IMapper _mapper;

        public MarcaAppService(IMarcaService marcaService, IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }

        public async Task<List<MarcaResponse>> GetAllAsync()
        {
            var response = await _marcaService.GetAllAsync();

            return _mapper.Map<List<MarcaResponse>>(response);
        }
    }
}
