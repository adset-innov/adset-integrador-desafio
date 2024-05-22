using ADSET.Application.DTOs.Request;
using ADSET.Application.DTOs.Requests;
using ADSET.Application.DTOs.Response;
using ADSET.Application.DTOs.Responses;

namespace ADSET.Application.Interfaces
{
    public interface IVeiculoAppService
    {
        VeiculoPaginatedResponse GetByFilter(FilterPaginationRequest request);
        Task<List<string>> GetAllColors();
        Task<VeiculoResponse> Create(VeiculoRequest request);
    }
}
