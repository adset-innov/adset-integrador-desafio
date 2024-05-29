using ADSET.Application.DTOs.Requests;
using ADSET.Application.DTOs.Responses;
using ADSET.Application.Interfaces;
using ADSET.Domain.Interfaces.Services;
using AutoMapper;

namespace ADSET.Application.Services
{
    public class FotoAppService : IFotoAppService
    {
        private readonly IFotoService _fotoService;
        private readonly IMapper _mapper;

        public FotoAppService(IFotoService fotoService, IMapper mapper)
        {
            _fotoService = fotoService;
            _mapper = mapper;
        }

        public async Task Delete(Guid id)
        {
            await _fotoService.DeleteAsync(id);
        }

        public async Task<List<FotoResponse>> GetFotoByVeiculo(Guid veiculoId)
        {
            var result = await _fotoService
                .GetFotoByVeiculo(veiculoId);

            return _mapper.Map<List<FotoResponse>>(result);
        }

        public async Task<List<FotoResponse>> UpdateFotos(List<VeiculoFotoRequest> request)
        {
            request.ForEach(r => r.Validate());

            var response = await _fotoService.CreateAsync(_mapper.Map<List<Domain.DTOs.Request.VeiculoFotoRequest>>(request));

            return _mapper.Map<List<FotoResponse>>(response);
        }
    }
}
