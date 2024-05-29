using ADSET.Application.DTOs.Requests;

namespace ADSET.Application.Interfaces
{
    public interface IPacoteAppService
    {
        Task SavePacotes(List<SavePacoteRequest> request);
    }
}
