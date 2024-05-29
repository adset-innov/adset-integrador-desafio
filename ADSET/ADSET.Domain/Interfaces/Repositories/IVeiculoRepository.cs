using ADSET.Domain.DTOs.Request;
using ADSET.Domain.DTOs.Response;
using ADSET.Domain.Entities;
using ADSET.Domain.Enums;

namespace ADSET.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        IQueryable<Veiculo> GetQuery();
        int CountQueryFilter(IQueryable<Veiculo> query);
        Task<List<string>> GetAllColorsQuery();
        VeiculoCountResponse GetCount();
        IQueryable<Veiculo> Filter(FilterPaginationRequest request);
        IQueryable<Veiculo> OrdeningQuery(IQueryable<Veiculo> query, List<Ordenacao>? orderByAsc, List<Ordenacao>? orderByDesc);
        Task<Veiculo?> GetById(Guid id);
        Task CreateVeiculoOpcionalList(List<VeiculoOpcional> request);
        void UpdateVeiculoOpcionalList(List<VeiculoOpcional> request);
        Task<List<VeiculoOpcional>> GetVeiculoOpcionalList(Guid veiculoId);
    }
}
