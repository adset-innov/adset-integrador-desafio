using ADSET.Application.DTOs.Requests;
using ADSET.Application.DTOs.Responses;

namespace ADSET.Application.Interfaces
{
    public interface IFotoAppService
    {
        Task Delete(Guid id);
        Task<List<FotoResponse>> GetFotoByVeiculo(Guid veiculoId);
        Task<List<FotoResponse>> UpdateFotos(List<VeiculoFotoRequest> request);
    }
}
