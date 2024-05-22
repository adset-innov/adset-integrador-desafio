using AdSetDesafio.Infrastructure.Enum;

namespace AdSetDesafio.Infrastructure.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create(DbType dbType);
    }
}