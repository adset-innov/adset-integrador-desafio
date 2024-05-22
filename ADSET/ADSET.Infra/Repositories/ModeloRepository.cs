using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ADSET.Infra.Repositories
{
    public class ModeloRepository : BaseRepository<Modelo>, IModeloRepository
    {
        private readonly SqlContext _context;

        public ModeloRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Modelo>> GetAllByMarca(Guid marcaId)
        {
            return await _context.Modelos
                .Where(x => x.MarcaId == marcaId)
                .ToListAsync();
        }
    }
}
