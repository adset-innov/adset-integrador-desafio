using ADSET.Application.DTOs.Requests;
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


        public async Task<VeiculoResponse> Update(VeiculoEditRequest request)
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

            var response = await _veiculoService.UpdateAsync(
                _mapper.Map<Veiculo>(request), request.Opcionais);

            return _mapper.Map<VeiculoResponse>(response);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _veiculoService.DeleteAsync(id);
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

        public async Task<VeiculoResponse> GetById(Guid guid)
        {
            if (Guid.Empty == guid)
                throw new Exception("Id nao identificado");

            return _mapper.Map<VeiculoResponse>(
                await _veiculoService.GetByIdAsync(guid));
        }

        public VeiculoCountResponse GetCount()
        {
            return _mapper.Map<VeiculoCountResponse>(_veiculoService.GetCount());
        }
    }
}
