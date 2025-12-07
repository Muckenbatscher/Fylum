namespace Fylum.Users.Application.Login;

public record UserLoginResult(Guid UserId, Guid RefreshTokenId, DateTimeOffset RefreshTokenExpiration);