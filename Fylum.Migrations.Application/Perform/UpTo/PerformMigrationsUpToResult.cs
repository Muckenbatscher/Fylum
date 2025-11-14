using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Application.Perform.UpTo;

public record PerformMigrationsUpToResult(IEnumerable<MigrationWithPerformedState> PerformedMigrations);