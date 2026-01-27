using Npgsql;
using System.Data;

namespace Fylum.Infrastructure.Postgres.Shared.Connection;

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