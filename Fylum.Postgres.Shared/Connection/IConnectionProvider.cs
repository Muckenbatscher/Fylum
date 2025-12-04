using System.Data;

namespace Fylum.Postgres.Shared.Connection;

public interface IConnectionProvider
{
    IDbConnection CreateConnection();
}