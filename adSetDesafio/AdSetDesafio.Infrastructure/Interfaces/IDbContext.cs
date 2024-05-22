using AdSetDesafio.Infrastructure.Enum;

namespace AdSetDesafio.Infrastructure.Interfaces
{
    public interface IDbContext
    {
        DbType DbType { get; }
        
        System.Data.IDbConnection GetConnection();
    }
}