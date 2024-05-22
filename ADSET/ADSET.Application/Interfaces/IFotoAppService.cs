using ADSET.Application.DTOs.Responses;

namespace ADSET.Application.Interfaces
{
    public interface IFotoAppService
    {
        Task<List<FotoResponse>> GetFotoByVeiculo(Guid veiculoId);
    }
}
