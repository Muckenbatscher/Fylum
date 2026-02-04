using System.Data;

namespace Fylum.Core.Infrastructure.Postgres;

public interface IConnectionProvider
{
    IDbConnection CreateConnection();
}