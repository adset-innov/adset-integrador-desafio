using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Services
{
    public interface IPacoteService
    {
        Task SavePacotes(List<Pacote> request);
    }
}
