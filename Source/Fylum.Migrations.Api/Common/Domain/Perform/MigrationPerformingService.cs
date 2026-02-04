using Fylum.Migrations.Api.Common.Domain.Providing;

namespace Fylum.Migrations.Api.Common.Domain.Perform;

public class MigrationPerformingService : IMigrationPerformingService
{
    private readonly IPerformedMigrationsRepository _performedMigrationsRepository;
    private readonly IScriptExecutor _scriptExecutor;

    public MigrationPerformingService(IPerformedMigrationsRepository performedMigrationsRepository, IScriptExecutor scriptExecutor)
    {
        _performedMigrationsRepository = performedMigrationsRepository;
        _scriptExecutor = scriptExecutor;
    }

    public Migration Perform(ProvidedMigration migration)
    {
        foreach (var script in migration.MigrationScripts)
            _scriptExecutor.Execute(script.ScriptCommandText);

        var performedMigration = PerformedMigration.CreateNew(migration);
        _performedMigrationsRepository.AddPerformedMigration(performedMigration);

        return Migration.Create(migration, performedMigration.Timestamp);
    }
}