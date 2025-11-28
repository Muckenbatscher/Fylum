using Fylum.Migrations.Domain.WithPerformedState;

namespace Fylum.Migrations.Application.Perform.All;

public record PerformAllMigrationsResult(IEnumerable<MigrationWithPerformedState> PerformedMigrations);