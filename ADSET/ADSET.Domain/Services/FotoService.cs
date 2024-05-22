using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.Services;

namespace ADSET.Domain.Services
{
    public class FotoService : IFotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVeiculoService _veiculoService;

        public FotoService(IUnitOfWork unitOfWork, IVeiculoService veiculoService)
        {
            _unitOfWork = unitOfWork;
            _veiculoService = veiculoService;
        }


        public async Task<int> CountFotoByVeiculo(Guid veiculoId)
        {
            Veiculo veiculo = await _veiculoService.GetByIdAsync(veiculoId);

            return _unitOfWork.FotoRepository.CountByVeiculo(veiculo.Id);
        }

        public Task<Foto> CreateAsync(FileStream foto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Foto>> CreateListAsync(List<FileStream> fotos)
        {
            throw new NotImplementedException();
        }

        private async Task<Foto> GetById(Guid id)
        {
            var foto = await _unitOfWork.FotoRepository.GetByIdAsync(id);

            if (foto == null)
                throw new Exception($"Foto com o ID: {id} não foi encontrado");

            return foto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var foto = await GetById(id);

            _unitOfWork.FotoRepository.RemoveFoto(foto);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<List<Foto>> GetFotoByVeiculo(Guid veiculoId)
        {
            Veiculo veiculo = await _veiculoService.GetByIdAsync(veiculoId);

            return await _unitOfWork.FotoRepository.GetAllByVeiculo(veiculo.Id);
        }
    }
}
