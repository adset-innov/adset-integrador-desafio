using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ADSET.Infra.Repositories
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        private readonly SqlContext _context;

        public MarcaRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public override Task<List<Marca>> GetAllAsync()
        { 
            return _context.Marcas
                .Include(m => m.Modelos.OrderBy(m => m.Nome))
                .OrderBy(m => m.Nome)
                .ToListAsync();
        }

    }
}
