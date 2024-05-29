using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ADSET.Infra.Repositories
{
    public class FotoRepository : BaseRepository<Foto>, IFotoRepository
    {
        private readonly SqlContext _context;

        public FotoRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public int CountByVeiculo(Guid veiculoId)
        {
            return _context.Fotos
                .Where(x => x.IsActive && x.VeiculoId == veiculoId)
                .Count();
        }

        public async Task<List<Foto>> GetAllByVeiculo(Guid veiculoId)
        {
            return await _context.Fotos
                .Where(x => x.VeiculoId == veiculoId)
                .ToListAsync();
        }

        public void RemoveFoto(Foto foto)
        {
            _context.Fotos.Remove(foto);
        }

        public async Task CreateListAsync(List<Foto> fotos)
        {
            await _context.Fotos.AddRangeAsync(fotos);
            return;
        }
    }
}
