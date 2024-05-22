using ADSET.Application.DTOs.Responses;

namespace ADSET.Application.Interfaces
{
    public interface IMarcaAppService
    {
        Task<List<MarcaResponse>> GetAllAsync();
    }
}
