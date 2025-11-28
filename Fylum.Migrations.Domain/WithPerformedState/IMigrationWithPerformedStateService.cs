namespace Fylum.Migrations.Domain.WithPerformedState;

public interface IMigrationWithPerformedStateService
{
    IEnumerable<MigrationWithPerformedState> GetMigrationsWithPerformedState();
    IEnumerable<MigrationWithPerformedState> GetUnperformedMigrations();
    IEnumerable<MigrationWithPerformedState> GetMinimallyRequiredUnperformedMigrations();
    MigrationWithPerformedState? GetMigrationWithPerformedState(Guid id);
}
