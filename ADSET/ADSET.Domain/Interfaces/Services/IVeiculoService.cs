using ADSET.Domain.DTOs.Request;
using ADSET.Domain.DTOs.Response;
using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Services
{
    public interface IVeiculoService
    {
        Task<Veiculo> CreateAsync(Veiculo veiculo, List<Guid>? opcionais);
        Task<bool> DeleteAsync(Guid id);
        Task<Veiculo> GetByIdAsync(Guid id);
        VeiculoPaginatedResponse GetListAsync(FilterPaginationRequest request);
        Task<Veiculo> UpdateAsync(Veiculo veiculo);
        Task<List<string>> GetAllColors();
    }
}
