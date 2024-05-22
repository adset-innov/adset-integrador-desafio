using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ADSET.Infra.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        private readonly SqlContext _context;

        public VeiculoRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public int CountQueryFilter(IQueryable<Veiculo> query)
        {
            return query.Count();
        }

        public async Task<List<string>> GetAllColorsQuery()
        {
            return await _context.Veiculos
                .DistinctBy(v => v.Cor)
                .Select(v => v.Cor)
                .ToListAsync();
        }

        public IQueryable<Veiculo> GetQuery()
        {
            return _context.Veiculos
                .Where(v => v.IsActive)
                .Include(v => v.Marca)
                .Include(v => v.Modelo)
                .Include(v => v.VeiculoOpcionais)
                .Include(v => v.Fotos)
                .Include(v => v.Pacotes);
        }
    }
}
