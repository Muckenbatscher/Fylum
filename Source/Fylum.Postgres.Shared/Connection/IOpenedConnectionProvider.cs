using System.Data;

namespace Fylum.Postgres.Shared.Connection;

public interface IOpenedConnectionProvider
{
    IDbConnection GetOpenedConnection();
}