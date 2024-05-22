using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;

namespace ADSET.Infra.Repositories
{
    public class OpcionalRepository : BaseRepository<Opcional>, IOpcionalRepository
    {
        private readonly SqlContext _context;

        public OpcionalRepository(SqlContext context) : base(context)
        {
            _context = context;
        }
    }
}
