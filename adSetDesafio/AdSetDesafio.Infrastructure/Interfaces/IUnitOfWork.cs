using System.Threading.Tasks;
using AdSetDesafio.Infrastructure.Enum;

namespace AdSetDesafio.Infrastructure.Interfaces
{
    public interface IUnitOfWork 
    {
        DbType DbType { get; }

        System.Data.IDbTransaction GetTransaction();

        Task<bool> Commit();
    }
}