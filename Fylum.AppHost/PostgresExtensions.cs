using Aspire.Hosting.Postgres;

namespace Fylum.AppHost;

public static class PostgresExtensions
{
    public static IResourceBuilder<PostgresServerResource> WithPreconfiguredPgAdmin(
        this IResourceBuilder<PostgresServerResource> postgresServer,
        IResourceBuilder<PostgresDatabaseResource> defaultConnectedDatabase,
        Action<IResourceBuilder<PgAdminContainerResource>>? configureContainer = null,
        string? containerName = null)
    {
        postgresServer.WithPgAdmin(
            containerName: containerName,
            configureContainer: pgAdminResource =>
            {
                pgAdminResource
                    .WithVolume(target: "/var/lib/pgadmin", name: "pgadmin_data")
                    .WithLifetime(ContainerLifetime.Persistent)
                    .WithSecureDynamicConfiguration(defaultConnectedDatabase);
                configureContainer?.Invoke(pgAdminResource);
            });
        return postgresServer;
    }
}