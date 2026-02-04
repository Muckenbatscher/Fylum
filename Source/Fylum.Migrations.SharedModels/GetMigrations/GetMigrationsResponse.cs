using System.Text.Json.Serialization;

namespace Fylum.Migrations.SharedModels.GetMigrations;

public record GetMigrationsResponse(
    [property: JsonPropertyName("migrations")] IEnumerable<MigrationDto> Migrations
    );
