using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Services
{
    public interface IOpcionalService
    {
        Task<List<Opcional>> GetAllAsync();
        Task<Opcional> GetById(Guid id);
        Task<bool> VeirfyExistsListId(List<Guid> ids);
    }
}
