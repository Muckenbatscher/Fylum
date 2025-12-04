namespace Fylum.Postgres.Shared.Connection;

public interface IConnectionStringProvider
{
    string GetConnectionString();
}