using AdSetDesafio.Infrastructure.Enum;

namespace AdSetDesafio.Infrastructure.Interfaces
{
    public interface IDbContextFactory
    {
        IDbContext Create(DbType dbType);
    }
}