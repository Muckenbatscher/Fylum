using System.Text.Json.Serialization;

namespace Fylum.Migrations.SharedModels.GetMigrationById;

public record GetMigrationByIdResponse(
    [property: JsonPropertyName("migration")] MigrationDto Migration
    );
