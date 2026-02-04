namespace Fylum.Core.Domain;

public interface IUnitOfWorkFactory<TUnitOfWork> : IDisposable
    where TUnitOfWork : IUnitOfWork
{
    TUnitOfWork Create();
}