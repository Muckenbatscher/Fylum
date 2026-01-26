namespace Fylum.Domain.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    void Rollback();
}