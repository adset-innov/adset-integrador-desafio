using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.Services;

namespace ADSET.Domain.Services
{
    public class PacoteService : IPacoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVeiculoService _veiculoService;

        public PacoteService(IVeiculoService veiculoService, IUnitOfWork unitOfWork)
        {
            _veiculoService = veiculoService;
            _unitOfWork = unitOfWork;
        }

        public async Task SavePacotes(List<Pacote> request)
        {
            try
            {
                var veiculos = _veiculoService
                    .GetAllIds(request.Select(r => r.VeiculoId)
                    .ToList());

                if (veiculos.Count != request.Count)
                    throw new Exception("Erro ao salvar os pacotes");

                request.ForEach(r =>
                {
                    r.Add();
                    _unitOfWork.PacoteRepository.CreateAsync(r);
                });

                if (await _unitOfWork.CommitAsync() == false)
                    throw new Exception("Pacotes nao salvos");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Salvar os pacotes", ex);
            }
        }
    }
}
