namespace Fylum.Domain.UnitOfWork;

public interface IUnitOfWorkTransactionFactory : IDisposable
{
    UnitOfWorkTransaction GetTransaction();
}