using System.Text.Json.Serialization;

namespace Fylum.Migrations.Shared;

public record MigrationScriptDto(
    [property: JsonPropertyName("command")] string Command);
