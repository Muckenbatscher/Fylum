using System.Data;

namespace Fylum.Domain.UnitOfWork;

public class UnitOfWorkTransaction
{
    public UnitOfWorkTransaction(IDbConnection connection, IDbTransaction transaction)
    {
        Connection = connection;
        Transaction = transaction;
    }

    public IDbConnection Connection { get; private set; }
    public IDbTransaction Transaction { get; private set; }
}