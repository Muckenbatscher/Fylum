namespace Fylum.Infrastructure.Postgres.Shared.Connection;

public interface IConnectionStringProvider
{
    string GetConnectionString();
}