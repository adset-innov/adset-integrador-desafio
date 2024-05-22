using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Services
{
    public interface IModeloService
    {
        Task<Modelo> GetById(Guid id);
    }
}
