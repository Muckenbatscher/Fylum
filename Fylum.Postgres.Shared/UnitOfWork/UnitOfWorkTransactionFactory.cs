using Fylum.Domain.UnitOfWork;
using Fylum.Postgres.Shared.Connection;
using System.Data;

namespace Fylum.Postgres.Shared.UnitOfWork;

public class UnitOfWorkTransactionFactory : IUnitOfWorkTransactionFactory
{
    private readonly IOpenedConnectionProvider _connectionProvider;

    private IDbConnection? _connection;
    private IDbTransaction? _transaction;

    public UnitOfWorkTransactionFactory(IOpenedConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public UnitOfWorkTransaction GetTransaction()
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            _connection = _connectionProvider.GetOpenedConnection();
            _transaction = _connection.BeginTransaction();
        }
        if (_transaction == null)
        {
            _transaction = _connection.BeginTransaction();
        }

        return new UnitOfWorkTransaction(_connection, _transaction);
    }


    public void Dispose()
    {
        if (_transaction != null)
            _transaction.Dispose();

        if (_connection != null)
            _connection.Dispose();
    }

}