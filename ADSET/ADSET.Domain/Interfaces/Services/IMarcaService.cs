using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Services
{
    public interface IMarcaService
    {
        Task<List<Marca>> GetAllAsync();
        Task<Marca> GetById(Guid id);
    }
}
