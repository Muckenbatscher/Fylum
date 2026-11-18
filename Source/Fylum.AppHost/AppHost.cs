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
        var api = builder.AddDotnetProject("api", "../Fylum.Api/Fylum.Api.csproj")
            .WithReference(database, "postgres")
            .WaitFor(database)
            .WithExternalHttpEndpoints()
            .WithScalarDisplayNameUrls()
            .WithOpenApiSpecUrl()
            .WithEnvironment("JWT_SIGNING_KEY", jwtSigningKey);

        var web = builder.AddDotnetProject("web", "../Fylum.Web/Fylum.Web.csproj")
            .WithReference(api, "api")
            .WithChildRelationship(api)
            .WaitFor(api)
            .WithExternalHttpEndpoints();

        var migrationPerformingKey = builder.AddParameter("MigrationPerformingKey", secret: true);
        var migrationsApi = builder.AddDotnetProject("migrations-api", "../Fylum.Migrations.Api/Fylum.Migrations.Api.csproj")
            .WithReference(database, "postgres")
            .WaitFor(database)
            .WithExternalHttpEndpoints()
            .WithScalarDisplayNameUrls()
            .WithOpenApiSpecUrl()
            .WithEnvironment("MIGRATION_PERFORMING_KEY", migrationPerformingKey)
            .WithMigrationCommands(migrationPerformingKey);

        var migrationsWeb = builder.AddDotnetProject("migrations-web", "../Fylum.Migrations.Web/Fylum.Migrations.Web.csproj")
            .WithReference(migrationsApi, "migrations-api")
            .WithChildRelationship(migrationsApi)
            .WaitFor(migrationsApi)
            .WithExternalHttpEndpoints()
            .WithEnvironment("MIGRATION_PERFORMING_KEY", migrationPerformingKey);

        var app = builder.Build();

        app.Run();
    }
}