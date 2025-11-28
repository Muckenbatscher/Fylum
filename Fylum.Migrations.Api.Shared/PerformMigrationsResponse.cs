namespace Fylum.Migrations.Api.Shared;

public record PerformMigrationsResponse(IEnumerable<MigrationResponse> PerformedMigrations);