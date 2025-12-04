namespace Fylum.Users.Api.Shared;

public record RegisterResponse(Guid UserId, string AccessToken, string RefreshToken);