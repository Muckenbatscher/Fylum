using Fylum.PostgreSql.Migration.Domain.UnitOfWork;
using Fylum.PostgreSql.Shared.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migrations.PostgreSql
{
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
    }
}
