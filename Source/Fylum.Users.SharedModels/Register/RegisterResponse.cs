using System.Text.Json.Serialization;

namespace Fylum.Users.SharedModels.Register;

public record RegisterResponse(
    [property: JsonPropertyName("user")] UserDto User,
    [property: JsonPropertyName("tokens")] TokenPairDto Tokens);