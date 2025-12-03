namespace Fylum.Api.Shared.JwtAuthentication;

public interface IJwtTokenBuilder
{
    string BuildAccessToken(Guid userId);
    string BuildRefreshToken(Guid userId, Guid refreshId);
}