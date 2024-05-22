using ADSET.Application.DTOs.Request;
using ADSET.Application.DTOs.Response;

namespace ADSET.Application.Interfaces
{
    public interface IVeiculoAppService
    {
        VeiculoPaginatedResponse GetByFilter(FilterPaginationRequest request);
        Task<List<string>> GetAllColors();
    }
}
