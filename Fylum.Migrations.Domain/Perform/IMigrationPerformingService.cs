using Fylum.Migrations.Domain.Providing;

namespace Fylum.Migrations.Domain.Perform;

public interface IMigrationPerformingService
{
    Migration Perform(ProvidedMigration migration);
}
