using Fylum.Migrations.Domain;
using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Application.Perform;

public class MigrationPerformingService : IMigrationPerformingService
{
    private readonly IPerformedMigrationsRepository _performedMigrationsRepository;
    private readonly IScriptExecutor _scriptExecutor;

    public MigrationPerformingService(IPerformedMigrationsRepository performedMigrationsRepository, IScriptExecutor scriptExecutor)
    {
        _performedMigrationsRepository = performedMigrationsRepository;
        _scriptExecutor = scriptExecutor;
    }

    public MigrationWithPerformedState Perform(Migration migration)
    {
        foreach (var script in migration.MigrationScripts)
            _scriptExecutor.Execute(script.ScriptCommandText);

        var performedMigration = CreatePerformedMigration(migration);
        _performedMigrationsRepository.AddPerformedMigration(performedMigration);

        return MigrationWithPerformedState.Create(migration, performedMigration.Timestamp);
    }

    private static PerformedMigration CreatePerformedMigration(Migration migration)
    {
        var dbMigration = Migration.Create(
            migration.Id,
            migration.Name);
        var performedMigration = PerformedMigration.CreateNew(dbMigration);
        return performedMigration;
    }
}
