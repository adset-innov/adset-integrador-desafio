using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.Services;

namespace ADSET.Domain.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModeloService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Modelo> GetById(Guid id)
        {
            var modelo = await _unitOfWork.ModeloRepository.GetByIdAsync(id);

            if (modelo == null)
                throw new Exception($"Modelo com o ID: {id} não foi encontrado");

            return modelo;
        }
    }
}
