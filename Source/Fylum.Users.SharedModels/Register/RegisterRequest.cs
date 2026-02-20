using System.Text.Json.Serialization;

namespace Fylum.Users.SharedModels.Register;

public record RegisterRequest(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("password")] string Password);