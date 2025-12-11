namespace Fylum.AppHost;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var portConfig = builder.Configuration["Postgres:Port"];
        var postgresPort = int.TryParse(portConfig, out int port) ? port : 56789;
        var postgres = builder.AddPostgres("postgres", port: postgresPort)
            .WithDataVolume("fylum_pgdata")
            .WithLifetime(ContainerLifetime.Persistent);
        var database = postgres.AddDatabase("fylum");
        postgres.WithPreconfiguredPgAdmin(database, containerName: "pgadmin");

        var api = builder.AddProject<Projects.Fylum_Api>("api")
            .WithReference(database, "postgres")
            .WaitFor(database)
            .WithScalarDisplayNameUrls()
            .WithOpenApiSpecUrl();

        var migrationPerformingKey = builder.AddParameter("MigrationPerformingKey", secret: true);
        var migrationsApi = builder.AddProject<Projects.Fylum_Migrations_Api>("migrations-api")
            .WithReference(database, "postgres")
            .WaitFor(database)
            .WithScalarDisplayNameUrls()
            .WithOpenApiSpecUrl()
            .WithEnvironment("MIGRATION_PERFORMING_KEY", migrationPerformingKey)
            .WithChildRelationship(migrationPerformingKey)
            .WithMigrationCommands(migrationPerformingKey);

        var app = builder.Build();

        app.Run();
    }
}