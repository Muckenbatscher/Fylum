using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Shared.Connection
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public ConnectionProvider(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _connectionStringProvider.GetConnectionString();
            return new NpgsqlConnection(connectionString);
        }
    }
}
