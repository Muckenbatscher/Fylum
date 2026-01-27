using FastEndpoints.Security;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Fylum.Api.Shared.JwtAuthentication;

public class JwtTokenBuilder : IJwtTokenBuilder
{
    private readonly JwtAuthOptions _jwtAuthOptions;

    public JwtTokenBuilder(IOptions<JwtAuthOptions> jwtAuthOptions)
    {
        _jwtAuthOptions = jwtAuthOptions.Value;
    }

    public string BuildAccessToken(Guid userId)
    {
        var userIdClaim = new Claim(JwtAuthConstants.UserIdClaim, userId.ToString());
        var expiration = DateTimeOffset.UtcNow.Add(_jwtAuthOptions.AccessTokenExpiration);
        return BuildToken([userIdClaim], expiration);
    }
    public string BuildRefreshToken(Guid userId, Guid refreshId, DateTimeOffset refreshTokenExpiration)
    {
        var userIdClaim = new Claim(JwtAuthConstants.RefreshUserIdClaim, userId.ToString());
        var refreshIdClaim = new Claim(JwtAuthConstants.RefreshIdClaim, refreshId.ToString());
        return BuildToken([userIdClaim, refreshIdClaim], refreshTokenExpiration);
    }

    private string BuildToken(IEnumerable<Claim> claims, DateTimeOffset expiration)
    {
        var signingKey = _jwtAuthOptions.SigningKey;

        var jwtToken = JwtBearer.CreateToken(o =>
        {
            o.SigningKey = signingKey;
            o.SigningAlgorithm = "HS256";
            o.ExpireAt = expiration.UtcDateTime;
            o.User.Claims.Add(claims.ToArray());
        });
        return jwtToken;
    }
}