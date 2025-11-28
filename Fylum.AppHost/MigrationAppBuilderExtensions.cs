using Fylum.Migrations.Api.Shared;

namespace Fylum.AppHost;

internal static class MigrationAppBuilderExtensions
{
    extension<TProject>(IResourceBuilder<TProject> projectBuilder) where TProject : ProjectResource
    {
        public IResourceBuilder<TProject> WithMigrationCommands(IResourceBuilder<ParameterResource> migrationPerformingKey)
        {
            return projectBuilder
                .WithMigrateMinimallyRequiredCommand(migrationPerformingKey)
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
        private IResourceBuilder<TProject> WithMigrateMinimallyRequiredCommand(IResourceBuilder<ParameterResource> migrationPerformingKey)
        {
            return projectBuilder.WithHttpCommand(
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
                       PrepareContextHeaderWithMigrationPerformingKey(context, migrationPerformingKey);
                       return Task.CompletedTask;
                   },
                   IconName = "DatabaseLightning"
               });
        }
    }


    private static void PrepareContextHeaderWithMigrationPerformingKey(
        HttpCommandRequestContext context,
        IResourceBuilder<ParameterResource> migrationPerformingKey)
    {
        const string performingKeyHeader = "X-MigrationPerforming-Key";
        var key = migrationPerformingKey.Resource.GetValueAsync(context.CancellationToken);
        context.Request.Headers.Add(performingKeyHeader, $"Key: {key}");
    }
}
