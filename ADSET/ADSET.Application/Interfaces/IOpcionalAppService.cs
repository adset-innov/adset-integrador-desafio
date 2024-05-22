using ADSET.Application.DTOs.Responses;

namespace ADSET.Application.Interfaces
{
    public interface IOpcionalAppService
    {
        Task<List<OpcionalResponse>> GetAllAsync();
    }
}
