using System.Text.Json.Serialization;

namespace Fylum.Users.SharedModels.GetUserById;

public record GetUserByIdResponse(
    [property: JsonPropertyName("user")] UserDto User);
