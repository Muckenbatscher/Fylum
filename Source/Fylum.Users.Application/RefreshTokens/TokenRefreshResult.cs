namespace Fylum.Users.Application.RefreshTokens;

public record TokenRefreshResult(Guid UserId, Guid TokenRefreshId, DateTimeOffset RefreshTokenExpiration);