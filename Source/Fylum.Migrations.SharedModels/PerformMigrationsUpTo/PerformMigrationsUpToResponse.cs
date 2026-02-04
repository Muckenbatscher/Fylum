using System.Text.Json.Serialization;

namespace Fylum.Migrations.Shared.PerformMigrationsUpTo;

public record PerformMigrationsUpToResponse(
    [property: JsonPropertyName("performed_migrations")] IEnumerable<MigrationDto> PerformedMigrations
    );
