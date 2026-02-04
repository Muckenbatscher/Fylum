namespace Fylum.Core.Infrastructure.Postgres;

public interface IConnectionStringProvider
{
    string GetConnectionString();
}