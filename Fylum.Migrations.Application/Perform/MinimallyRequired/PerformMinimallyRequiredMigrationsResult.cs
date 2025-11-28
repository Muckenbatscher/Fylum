using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Application.Perform.MinimallyRequired;

public record PerformMinimallyRequiredMigrationsResult(IEnumerable<MigrationWithPerformedState> PerformedMigrations);
