using FastEndpoints.Security;
using Fylum.Api.Authentication;
using Fylum.Domain.Users;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Fylum.Api
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly JwtAuthOptions _jwtAuthOptions;

        public JwtAuthService(IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        public string UserIdClaimKey => _jwtAuthOptions.UserIdClaim;

        public string BuildToken(Guid userId)
        {
            var signingKey = _jwtAuthOptions.SigningKey;
            var userIdClaim = _jwtAuthOptions.UserIdClaim;
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

        public Guid? GetUserIdFromClaims(IEnumerable<Claim> claims)
        {
            var userIdClaim = claims.SingleOrDefault(c => c.Type == _jwtAuthOptions.UserIdClaim);

            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
                return null;

            return userId;
        }
    }
}
