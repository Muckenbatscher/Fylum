using System.Data;

namespace Fylum.Infrastructure.Postgres.Shared.Connection;

public interface IOpenedConnectionProvider
{
    IDbConnection GetOpenedConnection();
}