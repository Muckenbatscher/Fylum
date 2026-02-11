namespace Fylum.Users.Api.Features.RefreshAccessToken;

public record TokenRefreshResult(Guid UserId, Guid TokenRefreshId, DateTimeOffset RefreshTokenExpiration);