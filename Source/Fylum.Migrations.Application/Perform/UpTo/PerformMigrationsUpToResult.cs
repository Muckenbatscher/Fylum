using Fylum.Migrations.Domain;

namespace Fylum.Migrations.Application.Perform.UpTo;

public record PerformMigrationsUpToResult(IEnumerable<Migration> PerformedMigrations);