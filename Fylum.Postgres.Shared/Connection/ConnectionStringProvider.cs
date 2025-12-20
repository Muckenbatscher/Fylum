using Microsoft.Extensions.Options;
using Npgsql;

namespace Fylum.Postgres.Shared.Connection;

public class ConnectionStringProvider : IConnectionStringProvider
{
    private const string FylumApplicationName = "FylumApi";

    private readonly IOptionsMonitor<DatabaseConnectionDetails> _connectionDetails;

    public ConnectionStringProvider(IOptionsMonitor<DatabaseConnectionDetails> dbConnectionDetails)
    {
        _connectionDetails = dbConnectionDetails;
    }

    public string GetConnectionString()
        => CreateConnectionStringBuilder(_connectionDetails.CurrentValue).ConnectionString;

    private static NpgsqlConnectionStringBuilder CreateConnectionStringBuilder(DatabaseConnectionDetails connectionDetails)
    {
        var connectionString = connectionDetails.ConnectionString;
        return new NpgsqlConnectionStringBuilder(connectionDetails.ConnectionString)
        {
            ApplicationName = FylumApplicationName
        };
    }
}