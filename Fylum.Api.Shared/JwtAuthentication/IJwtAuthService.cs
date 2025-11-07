using System.Security.Claims;

namespace Fylum.Api.Shared.JwtAuthentication
{
    public interface IJwtAuthService
    {
        string UserIdClaimKey { get; }

        string BuildToken(Guid userId);
        Guid? GetUserIdFromClaims(IEnumerable<Claim> claims);
    }
}