using System.Text.Json.Serialization;

namespace Fylum.Migrations.Shared.GetMigrations;

public record GetMigrationsResponse(
    [property: JsonPropertyName("migrations")] IEnumerable<MigrationDto> Migrations
    );
