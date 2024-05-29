using ADSET.Application.DTOs.Requests;
using ADSET.Application.Interfaces;
using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces.Services;
using AutoMapper;

namespace ADSET.Application.Services
{
    public class PacoteAppService : IPacoteAppService
    {
        private readonly IPacoteService _pacoteService;
        private readonly IMapper _mapper;

        public PacoteAppService(IPacoteService pacoteService, IMapper mapper)
        {
            _pacoteService = pacoteService;
            _mapper = mapper;
        }

        public async Task SavePacotes(List<SavePacoteRequest> request)
        {
            request.ForEach(r => r.Validate());

            await _pacoteService.SavePacotes(_mapper.Map<List<Pacote>>(request));
        }
    }
}
