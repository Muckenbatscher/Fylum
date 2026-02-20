namespace Fylum.Core.Presentation.Api.JwtAuthentication;

public interface IJwtTokenBuilder
{
    string BuildAccessToken(Guid userId);
    string BuildRefreshToken(Guid userId, Guid refreshId, DateTimeOffset refreshTokenExpiration);
}