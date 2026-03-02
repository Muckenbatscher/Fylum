using Microsoft.Extensions.Configuration;

namespace Fylum.AppHost;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);
        var compose = builder.AddDockerComposeEnvironment("compose");
        bool isPersistent = !builder.Configuration.GetValue("NonPersistent", false);

        var postgresPort = builder.Configuration.GetValue("Postgres:Port", 56789);
        var postgres = builder.AddPostgres("postgres", port: postgresPort);
        if (isPersistent)
        {
            postgres.WithDataVolume("fylum_pgdata")
                .WithLifetime(ContainerLifetime.Persistent);
        }

        var database = postgres.AddDatabase("fylum");
        if (isPersistent)
            postgres.WithPreconfiguredPgAdmin(database, containerName: "pgadmin");

        var jwtSigningKey = builder.AddParameter("JwtSigningKey", secret: true);
        var api = builder.AddProject<Projects.Fylum_Api>("api")
            .WithReference(database, "postgres")
            .WaitFor(database)
            .WithExternalHttpEndpoints()
            .WithScalarDisplayNameUrls()
            .WithOpenApiSpecUrl()
            .WithEnvironment("JWT_SIGNING_KEY", jwtSigningKey);

        var web = builder.AddProject<Projects.Fylum_Web>("web")
            .WithReference(api, "api")
            .WithChildRelationship(api)
            .WaitFor(api)
            .WithExternalHttpEndpoints();

        var migrationPerformingKey = builder.AddParameter("MigrationPerformingKey", secret: true);
        var migrationsApi = builder.AddProject<Projects.Fylum_Migrations_Api>("migrations-api")
            .WithReference(database, "postgres")
            .WaitFor(database)
            .WithExternalHttpEndpoints()
            .WithScalarDisplayNameUrls()
            .WithOpenApiSpecUrl()
            .WithEnvironment("MIGRATION_PERFORMING_KEY", migrationPerformingKey)
            .WithMigrationCommands(migrationPerformingKey);

        var migrationsWeb = builder.AddProject<Projects.Fylum_Migrations_Web>("migrations-web")
            .WithReference(migrationsApi, "migrations-api")
            .WithChildRelationship(migrationsApi)
            .WaitFor(migrationsApi)
            .WithExternalHttpEndpoints()
            .WithEnvironment("MIGRATION_PERFORMING_KEY", migrationPerformingKey);

        var app = builder.Build();

        app.Run();
    }
}