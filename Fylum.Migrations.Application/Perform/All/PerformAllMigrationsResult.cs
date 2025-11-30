using Fylum.Migrations.Domain;

namespace Fylum.Migrations.Application.Perform.All;

public record PerformAllMigrationsResult(IEnumerable<Migration> PerformedMigrations);