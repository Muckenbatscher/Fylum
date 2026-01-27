using Fylum.Migrations.Domain.Providing;

namespace Fylum.Migrations.Domain;

public class Migration
{
    private Migration(ProvidedMigration migration, MigrationPeformedState? performedState)
    {
        ProvidedMigration = migration;
        PerformedState = performedState;
    }

    public ProvidedMigration ProvidedMigration { get; init; }
    public MigrationPeformedState? PerformedState { get; private set; }

    public bool IsPerformed => PerformedState != null;

    public static Migration Create(ProvidedMigration migration, DateTimeOffset? performedTimestamp)
    {
        var performedState = performedTimestamp.HasValue
            ? new MigrationPeformedState(performedTimestamp.Value)
            : null;
        return new Migration(migration, performedState);
    }
}