namespace Fylum.Migrations.Domain.WithPerformedState;

public class MigrationWithPerformedState
{
    private MigrationWithPerformedState(Migration migration, MigrationPeformedState? performedState)
    {
        Migration = migration;
        PerformedState = performedState;
    }

    public Migration Migration { get; init; }
    public MigrationPeformedState? PerformedState { get; private set; }

    public bool IsPerformed => PerformedState != null;

    public static MigrationWithPerformedState Create(Migration migration, DateTimeOffset? performedTimestamp)
    {
        var performedState = performedTimestamp.HasValue
            ? new MigrationPeformedState(performedTimestamp.Value)
            : null;
        return new MigrationWithPerformedState(migration, performedState);
    }
}
