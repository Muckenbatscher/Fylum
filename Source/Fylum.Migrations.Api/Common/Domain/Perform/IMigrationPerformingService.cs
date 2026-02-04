using Fylum.Migrations.Api.Common.Domain.Providing;
using Fylum.Migrations.Domain.Providing;

namespace Fylum.Migrations.Api.Common.Domain.Perform;

public interface IMigrationPerformingService
{
    Migration Perform(ProvidedMigration migration);
}