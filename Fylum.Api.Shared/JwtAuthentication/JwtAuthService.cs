using FastEndpoints.Security;
using Microsoft.Extensions.Options;

namespace Fylum.Api.Shared.JwtAuthentication;

public class JwtAuthService : IJwtAuthService
{
    private readonly JwtAuthOptions _jwtAuthOptions;

    public JwtAuthService(IOptions<JwtAuthOptions> jwtAuthOptions)
    {
        _jwtAuthOptions = jwtAuthOptions.Value;
    }


    public string BuildToken(Guid userId)
    {
        var userIdClaim = JwtAuthConstants.UserIdClaim;
        var signingKey = _jwtAuthOptions.SigningKey;
        var expirationMinutes = _jwtAuthOptions.ExpirationInMinutes;

        var jwtToken = JwtBearer.CreateToken(o =>
        {
            o.SigningKey = signingKey;
            o.SigningAlgorithm = "HS256";
            o.ExpireAt = DateTime.UtcNow.AddMinutes(expirationMinutes);
            o.User.Claims.Add((userIdClaim, userId.ToString()));
        });
        return jwtToken;
    }
}