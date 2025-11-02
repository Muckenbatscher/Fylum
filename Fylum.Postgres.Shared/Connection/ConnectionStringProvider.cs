using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Postgres.Shared.Connection
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private const string ApplicationName = "FylumApi";

        private readonly DatabaseConnectionDetails _connectionDetails;

        public ConnectionStringProvider(IOptions<DatabaseConnectionDetails> dbConnectionDetails)
        {
            _connectionDetails = dbConnectionDetails.Value;
        }

        public string GetConnectionString()
        {
            var builder = CreateConnectionStringBuilder(_connectionDetails);
            return builder.ConnectionString;
        }

        private static NpgsqlConnectionStringBuilder CreateConnectionStringBuilder(DatabaseConnectionDetails connectionDetails)
        {
            return new NpgsqlConnectionStringBuilder
            {
                Host = connectionDetails.HostName,
                Port = connectionDetails.Port,
                Database = connectionDetails.DatabaseName,
                Username = connectionDetails.Username,
                Password = connectionDetails.Password,
                ApplicationName = ApplicationName
            };
        }
            
    }
}
