using System.Data;

namespace Fylum.Core.Infrastructure.Postgres;

public interface IOpenedConnectionProvider
{
    IDbConnection GetOpenedConnection();
}