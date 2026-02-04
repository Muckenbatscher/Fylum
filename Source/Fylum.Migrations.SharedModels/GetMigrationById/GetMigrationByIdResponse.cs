using System.Text.Json.Serialization;

namespace Fylum.Migrations.Shared.GetMigrationById;

public record GetMigrationByIdResponse(
    [property: JsonPropertyName("migration")] MigrationDto Migration
    );
