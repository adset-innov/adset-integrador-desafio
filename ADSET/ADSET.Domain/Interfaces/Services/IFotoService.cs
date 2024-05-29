using ADSET.Domain.DTOs.Request;
using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Services
{
    public interface IFotoService
    {
        Task<bool> DeleteAsync(Guid id);
        Task<List<Foto>> GetFotoByVeiculo(Guid veiculoId);
        Task<int> CountFotoByVeiculo(Guid veiculoId);
        Task<List<Foto>> CreateAsync(List<VeiculoFotoRequest> request);
    }
}
