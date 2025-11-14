using Fylum.Migrations.Api.Shared;

namespace Fylum.AppHost;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var database = builder.AddPostgres("postgres")
            .WithEnvironment("POSTGRES_DB", "fylum")
            .AddDatabase("fylum");

        var migrationPerformingKey = builder.AddParameter("MigrationPerformingKey", secret: true);

        var api = builder.AddProject<Projects.Fylum_Api>("api")
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
                    context.Request.Headers.Add("X-MigrationPerforming-Key", $"Key: {key}");
                    return Task.CompletedTask;
                },
                IconName = "DatabaseLightningRegular"
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
                    context.Request.Headers.Add("X-MigrationPerforming-Key", $"Key: {key}");
                    return Task.CompletedTask;
                },
                IconName = "DatabaseCheckmarkRegular"
            });

        var app = builder.Build();

        app.Run();
    }
}