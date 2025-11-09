namespace Fylum.Migrations.Api.Shared;

public record PerformMigrationsUpToResponse(IEnumerable<MigrationResponse> PerformedMigrations);