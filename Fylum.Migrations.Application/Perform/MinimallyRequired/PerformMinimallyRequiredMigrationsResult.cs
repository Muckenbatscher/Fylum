using Fylum.Migrations.Domain;

namespace Fylum.Migrations.Application.Perform.MinimallyRequired;

public record PerformMinimallyRequiredMigrationsResult(IEnumerable<Migration> PerformedMigrations);
