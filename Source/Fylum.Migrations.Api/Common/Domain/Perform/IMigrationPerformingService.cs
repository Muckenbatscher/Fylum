using Fylum.Migrations.Api.Common.Domain.Providing;

namespace Fylum.Migrations.Api.Common.Domain.Perform;

public interface IMigrationPerformingService
{
    Migration Perform(ProvidedMigration migration);
}