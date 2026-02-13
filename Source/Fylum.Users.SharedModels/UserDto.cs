using System.Text.Json.Serialization;

namespace Fylum.Users.SharedModels;

public record UserDto(
    [property: JsonPropertyName("id")] Guid Id,
    [property: JsonPropertyName("usernam")] string Username,
    [property: JsonPropertyName("is_active")] bool IsActive);
