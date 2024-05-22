using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        IQueryable<Veiculo> GetQuery();
        int CountQueryFilter(IQueryable<Veiculo> query);
        Task<List<string>> GetAllColorsQuery();
    }
}
