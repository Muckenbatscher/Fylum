namespace Fylum.Domain.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly IUnitOfWorkTransactionFactory _transactionFactory;

    public UnitOfWork(IUnitOfWorkTransactionFactory transactionFactory)
    {
        _transactionFactory = transactionFactory;
    }

    public void Commit()
    {
        var transaction = _transactionFactory.GetTransaction();
        transaction.Transaction.Commit();
    }

    public void Rollback()
    {
        var transaction = _transactionFactory.GetTransaction();
        transaction.Transaction.Rollback();
    }

    public void Dispose()
    {
        _transactionFactory.Dispose();
        GC.SuppressFinalize(this);
    }
}