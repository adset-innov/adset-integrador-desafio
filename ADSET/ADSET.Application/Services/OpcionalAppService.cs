using ADSET.Application.DTOs.Responses;
using ADSET.Application.Interfaces;
using ADSET.Domain.Interfaces.Services;
using AutoMapper;

namespace ADSET.Application.Services
{
    public class OpcionalAppService : IOpcionalAppService
    {
        private readonly IOpcionalService _opcionalService;
        private readonly IMapper _mapper;

        public OpcionalAppService(IOpcionalService opcionalService, IMapper mapper)
        {
            _opcionalService = opcionalService;
            _mapper = mapper;
        }

        public async Task<List<OpcionalResponse>> GetAllAsync()
        {
            var response = await _opcionalService.GetAllAsync();

            return _mapper.Map<List<OpcionalResponse>>(response);
        }
    }
}
