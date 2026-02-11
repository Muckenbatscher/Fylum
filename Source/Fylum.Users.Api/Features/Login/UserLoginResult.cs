namespace Fylum.Users.Api.Features.Login;

public record UserLoginResult(Guid UserId, Guid RefreshTokenId, DateTimeOffset RefreshTokenExpiration);