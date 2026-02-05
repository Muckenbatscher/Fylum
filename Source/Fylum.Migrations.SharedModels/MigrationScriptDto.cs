using System.Text.Json.Serialization;

namespace Fylum.Migrations.SharedModels;

public record MigrationScriptDto(
    [property: JsonPropertyName("command")] string Command);
