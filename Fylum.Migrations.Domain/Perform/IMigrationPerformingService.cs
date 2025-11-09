using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Domain.Perform;

public interface IMigrationPerformingService
{
    MigrationWithPerformedState Perform(Migration migration);
}
