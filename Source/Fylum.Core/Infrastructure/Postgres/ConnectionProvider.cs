using Npgsql;
using System.Data;

namespace Fylum.Core.Infrastructure.Postgres;

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