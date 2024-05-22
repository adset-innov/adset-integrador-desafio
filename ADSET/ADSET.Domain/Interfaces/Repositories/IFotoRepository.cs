using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Repositories
{
    public interface IFotoRepository : IBaseRepository<Foto>
    {
        Task<List<Foto>> GetAllByVeiculo(Guid veiculoId);
        int CountByVeiculo(Guid veiculoId);
        void RemoveFoto(Foto foto);
    }
}
