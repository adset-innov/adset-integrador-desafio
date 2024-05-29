using ADSET.Domain.DTOs.Request;
using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.ExternalServices;
using ADSET.Domain.Interfaces.Services;

namespace ADSET.Domain.Services
{
    public class FotoService : IFotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVeiculoService _veiculoService;
        private readonly IAwsS3ExternalService _awsS3;

        public FotoService(IUnitOfWork unitOfWork, IVeiculoService veiculoService, IAwsS3ExternalService awsS3)
        {
            _unitOfWork = unitOfWork;
            _veiculoService = veiculoService;
            _awsS3 = awsS3;
        }

        public async Task<int> CountFotoByVeiculo(Guid veiculoId)
        {
            Veiculo veiculo = await _veiculoService.GetByIdAsync(veiculoId);

            return _unitOfWork.FotoRepository.CountByVeiculo(veiculo.Id);
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
            try
            {
                var foto = await GetById(id);
                Veiculo veiculo = await _veiculoService.GetByIdAsync(foto.VeiculoId);

                await _awsS3.DeleteFileAsync(foto.Nome);

                _unitOfWork.FotoRepository.RemoveFoto(foto);

                if ((await CountFotoByVeiculo(foto.VeiculoId) - 1) == 0)
                    await _veiculoService.UpdateHaveFotoAsync(veiculo, false);
                
                return await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao fazer o apagar a imagem", ex);
            }
        }

        public async Task<List<Foto>> GetFotoByVeiculo(Guid veiculoId)
        {
            Veiculo veiculo = await _veiculoService.GetByIdAsync(veiculoId);

            return await _unitOfWork.FotoRepository.GetAllByVeiculo(veiculo.Id);
        }

        public async Task<List<Foto>> CreateAsync(List<VeiculoFotoRequest> request)
        {
            try
            {
                var veiculoId = request[0].VeiculoId;

                var veiculo = await _veiculoService.GetByIdAsync(veiculoId);

                var count = await CountFotoByVeiculo(veiculoId);

                if (count >= 15 || (request.Count + count) > 15)
                    throw new Exception("O limite de foto para esse veiculo já foi atingido");

                request.ForEach(r => r.ProcessName());

                await _awsS3.UpdateFilesToS3Bucket(request);

                var response = await _awsS3.GetFiltredFilesAsync(veiculoId.ToString(), request.Select(r => $"{veiculoId}/{r.Nome}").ToList());

                var fotos = response.Select(r => new Foto(r.PresignedUrl, r.Name, veiculoId)).ToList();

                await _unitOfWork.FotoRepository.CreateListAsync(fotos);

                await _veiculoService.UpdateHaveFotoAsync(veiculo, true);

                await _unitOfWork.CommitAsync();

                return fotos;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao fazer o upload das imagens", ex);
            }
        }
    }
}
