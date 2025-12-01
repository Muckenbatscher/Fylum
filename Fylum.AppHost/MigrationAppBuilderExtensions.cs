using Fylum.Migrations.Api.Shared;

namespace Fylum.AppHost;

internal static class MigrationAppBuilderExtensions
{
    extension<TProject>(IResourceBuilder<TProject> projectBuilder) where TProject : ProjectResource
    {
        public IResourceBuilder<TProject> WithMigrationCommands(IResourceBuilder<ParameterResource> migrationPerformingKey)
        {
            return projectBuilder
                .WithMigrateAllCommand(migrationPerformingKey);
        }

        private IResourceBuilder<TProject> WithMigrateAllCommand(IResourceBuilder<ParameterResource> migrationPerformingKey)
        {
            return projectBuilder.WithHttpCommand(
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
                        PrepareContextHeaderWithMigrationPerformingKey(context, migrationPerformingKey);
                        return Task.CompletedTask;
                    },
                    IconName = "DatabaseCheckmark"
                });
        }
    }

    private static void PrepareContextHeaderWithMigrationPerformingKey(
        HttpCommandRequestContext context,
        IResourceBuilder<ParameterResource> migrationPerformingKey)
    {
        var performingKeyHeader = PerfomAuthConstants.MigrationPerformingKeyHeaderName;
        var key = migrationPerformingKey.Resource.GetValueAsync(context.CancellationToken);
        context.Request.Headers.Add(performingKeyHeader, $"Key: {key}");
    }
}
