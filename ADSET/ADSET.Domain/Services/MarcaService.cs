using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.Services;

namespace ADSET.Domain.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public MarcaService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<Marca>> GetAllAsync()
        {
            return await _unitOfWork.MarcaRepository.GetAllAsync();
        }

        public async Task<Marca> GetById(Guid id)
        {
            var marca = await _unitOfWork.MarcaRepository.GetByIdAsync(id);

            if(marca == null) 
                throw new Exception($"Marca com o ID: {id} não foi encontrado");

            return marca;
        }
    }
}
