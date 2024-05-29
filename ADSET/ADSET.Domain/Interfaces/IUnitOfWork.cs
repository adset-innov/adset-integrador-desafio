using ADSET.Domain.Interfaces.Repositories;

namespace ADSET.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IVeiculoRepository VeiculoRepository { get; }
        IMarcaRepository MarcaRepository { get; }
        IModeloRepository ModeloRepository { get; }
        IFotoRepository FotoRepository { get; }
        IOpcionalRepository OpcionalRepository { get; }
        IPacoteRepository PacoteRepository { get; }

        Task<bool> CommitAsync();
        void Dispose();
    }
}
