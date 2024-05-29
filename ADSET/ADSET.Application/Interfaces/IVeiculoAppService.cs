using ADSET.Application.DTOs.Requests;
using ADSET.Application.DTOs.Responses;

namespace ADSET.Application.Interfaces
{
    public interface IVeiculoAppService
    {
        VeiculoPaginatedResponse GetByFilter(FilterPaginationRequest request);
        Task<List<string>> GetAllColors();
        Task<VeiculoResponse> Create(VeiculoRequest request);
        VeiculoCountResponse GetCount();
        Task<bool> Delete(Guid id);
        Task<VeiculoResponse> GetById(Guid guid);
        Task<VeiculoResponse> Update(VeiculoEditRequest request);
    }
}
