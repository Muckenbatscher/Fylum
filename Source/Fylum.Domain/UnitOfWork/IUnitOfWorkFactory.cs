namespace Fylum.Domain.UnitOfWork;

public interface IUnitOfWorkFactory<TUnitOfWork> : IDisposable
    where TUnitOfWork : IUnitOfWork
{
    TUnitOfWork Create();
}