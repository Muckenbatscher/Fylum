namespace Fylum.Users.Api.Models;

public record RegisterResponse(Guid UserId, string AccessToken, string RefreshToken);