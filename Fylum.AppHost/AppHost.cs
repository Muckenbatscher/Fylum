namespace Fylum.AppHost;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var postgres = builder.AddPostgres("postgres")
            .WithDataVolume("fylum_pgdata")
            .WithLifetime(ContainerLifetime.Persistent);
        var database = postgres.AddDatabase("fylum");
        postgres.WithPreconfiguredPgAdmin(database, containerName: "pgadmin");

        var api = builder.AddProject<Projects.Fylum_Api>("api")
            .WithReference(database, "postgres")
            .WaitFor(database);

        var migrationPerformingKey = builder.AddParameter("MigrationPerformingKey", secret: true);
        var migrationsApi = builder.AddProject<Projects.Fylum_Migrations_Api>("migrations-api")
            .WithReference(database, "postgres")
            .WaitFor(database)
            .WithEnvironment("MIGRATION_PERFORMING_KEY", migrationPerformingKey)
            .WithChildRelationship(migrationPerformingKey)
            .WithMigrationCommands(migrationPerformingKey);

        var app = builder.Build();

        app.Run();
    }
}