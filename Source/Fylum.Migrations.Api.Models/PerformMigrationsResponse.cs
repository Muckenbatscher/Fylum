namespace Fylum.Migrations.Api.Models;

public record PerformMigrationsResponse(IEnumerable<MigrationDto> PerformedMigrations);