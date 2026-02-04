namespace Fylum.Core.Domain;

public interface IUnitOfWorkTransactionFactory : IDisposable
{
    UnitOfWorkTransaction GetTransaction();
}