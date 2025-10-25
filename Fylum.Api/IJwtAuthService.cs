using System.Security.Claims;

namespace Fylum.Api
{
    public interface IJwtAuthService
    {
        string UserIdClaimKey { get; }

        string BuildToken(Guid userId);
        Guid? GetUserIdFromClaims(IEnumerable<Claim> claims);
    }
}