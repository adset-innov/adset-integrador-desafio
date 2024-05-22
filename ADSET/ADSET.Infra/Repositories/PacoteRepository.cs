using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;

namespace ADSET.Infra.Repositories
{
    public class PacoteRepository : BaseRepository<Pacote>, IPacoteRepository
    {
        private readonly SqlContext _context;

        public PacoteRepository(SqlContext context) : base(context)
            => _context = context;
    }
}
