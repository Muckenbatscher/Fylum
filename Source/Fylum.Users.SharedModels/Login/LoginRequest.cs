using System.Text.Json.Serialization;

namespace Fylum.Users.SharedModels.Login;

public record LoginRequest(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("password")] string Password);