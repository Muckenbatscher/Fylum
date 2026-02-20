using System.Text.Json.Serialization;

namespace Fylum.Users.SharedModels;

public record TokenPairDto(
    [property: JsonPropertyName("access_token")] string AccessToken,
    [property: JsonPropertyName("refresh_token")] string RefreshToken);