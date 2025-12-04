using System.Data;

namespace Fylum.Postgres.Shared.Connection;

public class OpenedConnectionProvider : IOpenedConnectionProvider
{
    private readonly IConnectionProvider _connectionProvider;

    public OpenedConnectionProvider(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IDbConnection GetOpenedConnection()
    {
        var connection = _connectionProvider.CreateConnection();
        if (connection.State != ConnectionState.Open)
            connection.Open();

        return connection;
    }
}