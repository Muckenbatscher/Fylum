using System.Text.Json.Serialization;

namespace Fylum.Users.SharedModels.Login;

public record LoginResponse(
    [property: JsonPropertyName("tokens")] TokenPairDto Tokens);