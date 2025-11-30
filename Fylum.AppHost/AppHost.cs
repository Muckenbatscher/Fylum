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

        var migrationPerformingKey = builder.AddParameter("MigrationPerformingKey", secret: true);

        var api = builder.AddProject<Projects.Fylum_Api>("api")
            .WithReference(database, "postgres")
            .WaitFor(database)
            .WithChildRelationship(migrationPerformingKey)
            .WithMigrationCommands(migrationPerformingKey);

        var app = builder.Build();

        app.Run();
    }
}