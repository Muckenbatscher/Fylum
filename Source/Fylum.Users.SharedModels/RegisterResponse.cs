namespace Fylum.Users.SharedModels;

public record RegisterResponse(Guid UserId, string AccessToken, string RefreshToken);