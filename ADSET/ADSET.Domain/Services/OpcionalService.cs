using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.Services;

namespace ADSET.Domain.Services
{
    public class OpcionalService : IOpcionalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OpcionalService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<Opcional>> GetAllAsync()
        {
            return await _unitOfWork.OpcionalRepository.GetAllAsync();
        }

        public async Task<Opcional> GetById(Guid id)
        {
            var marca = await _unitOfWork.OpcionalRepository.GetByIdAsync(id);

            if (marca == null)
                throw new Exception($"Opcional com o ID: {id} não foi encontrado");

            return marca;
        }

        public async Task<bool> VeirfyExistsListId(List<Guid> ids)
        {
            var opcionais = await _unitOfWork.OpcionalRepository.GetAllAsync();

            return opcionais.Where(o => ids.Contains(o.Id)).ToList().Count() == ids.Count();
        }
    }
}
