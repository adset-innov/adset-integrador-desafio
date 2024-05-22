using ADSET.Domain.Entities;

namespace ADSET.Domain.Interfaces.Services
{
    public interface IFotoService
    {
        Task<List<Foto>> CreateListAsync(List<FileStream> fotos);
        Task<Foto> CreateAsync(FileStream foto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Foto>> GetFotoByVeiculo(Guid veiculoId);
        Task<int> CountFotoByVeiculo(Guid veiculoId);
    }
}
