using System.Text.Json.Serialization;

namespace Fylum.Users.SharedModels.RefreshAccessToken;

public record TokenRefreshResponse(
    [property: JsonPropertyName("tokens")] TokenPairDto Tokens);