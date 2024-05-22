using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Repositories
{
    public interface IModeloRepository : IBaseRepository<Modelo>
    {
        Task<List<Modelo>> GetAllByMarca(Guid marcaId);
    }
}
