using Aspire.Hosting;
using Fylum.Migrations.Api.Shared;

namespace Fylum.AppHost;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var postgres = builder.AddPostgres("postgres")
            .WithDataVolume("fylum_pgdata")
            .WithPgAdmin(
            containerName: "pgadmin",
            configureContainer: pgAdminResource =>
            {
                pgAdminResource
                    .WithEnvironment("PGADMIN_CONFIG_SERVER_MODE", "False")
                    .WithEnvironment("PGADMIN_CONFIG_MASTER_PASSWORD_REQUIRED", "False")
                    .WithVolume(target: "/var/lib/pgadmin", name: "pgadmin_data");
                 });
        var database = postgres.AddDatabase("fylum");

        var migrationPerformingKey = builder.AddParameter("MigrationPerformingKey", secret: true);

        string performingKeyHeader = "X-MigrationPerforming-Key";
        var api = builder.AddProject<Projects.Fylum_Api>("api")
            .WithReference(database, "postgres")
            .WaitFor(database)
            .WithChildRelationship(migrationPerformingKey)
            .WithHttpCommand(
            path: EndpointRoutes.MigrationsPerformMinimallyRequiredRoute,
            displayName: "Perform Minimally Required Migrations",
            commandOptions: new HttpCommandOptions()
            {
                Description = """
                Migrates the database to the minimally required state.
                The migrations and users contexts are ensured to exist.
                """,
                PrepareRequest = (context) =>
                {
                    var key = migrationPerformingKey.Resource.GetValueAsync(context.CancellationToken);
                    context.Request.Headers.Add(performingKeyHeader, $"Key: {key}");
                    return Task.CompletedTask;
                },
                IconName = "DatabaseLightning"
            })
            .WithHttpCommand(
            path: EndpointRoutes.MigrationsPerformAllRoute,
            displayName: "Perform All Available Migrations",
            commandOptions: new HttpCommandOptions()
            {
                Description = """
                 Migrates the database to the latest available state.
                 All the contexts are ensured to exist.
                 """,
                PrepareRequest = (context) =>
                {
                    var key = migrationPerformingKey.Resource.GetValueAsync(context.CancellationToken);
                    context.Request.Headers.Add(performingKeyHeader, $"Key: {key}");
                    return Task.CompletedTask;
                },
                IconName = "DatabaseCheckmark"
            });

        var app = builder.Build();

        app.Run();
    }
}