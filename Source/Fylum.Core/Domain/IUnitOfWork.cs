namespace Fylum.Core.Domain;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    void Rollback();
}