using System.Text.Json.Serialization;

namespace Fylum.Migrations.SharedModels.PerformAllMigrations;

public record PerformAllMigrationsResponse(
    [property: JsonPropertyName("performed_migrations")] IEnumerable<MigrationDto> PerformedMigrations
    );
