namespace Fylum.Migrations.Domain.WithPerformedState;

public interface IMigrationWithPerformedStateService
{
    IEnumerable<MigrationWithPerformedState> GetMigrationsWithPerformedState();
    MigrationWithPerformedState? GetMigrationWithPerformedState(Guid id);
}
