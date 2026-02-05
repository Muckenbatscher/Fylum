using System.Text.Json.Serialization;

namespace Fylum.Migrations.SharedModels;

public record MigrationDto(
    [property: JsonPropertyName("id")] Guid Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("scripts")] IEnumerable<MigrationScriptDto> Scripts,
    [property: JsonPropertyName("is_performed")] bool IsPerformed,
    [property: JsonPropertyName("performed_utc")] DateTime? PerformedUtc);
