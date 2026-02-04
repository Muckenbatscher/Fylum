using System.Text.Json.Serialization;

namespace Fylum.Migrations.SharedModels.PerformMigrationsUpTo;

public record PerformMigrationsUpToResponse(
    [property: JsonPropertyName("performed_migrations")] IEnumerable<MigrationDto> PerformedMigrations
    );
