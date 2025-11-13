using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Application.Perform;

public record PerformMigrationsUpToResult(IEnumerable<MigrationWithPerformedState> PerformedMigrations);