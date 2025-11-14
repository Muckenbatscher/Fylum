using System.Security.Claims;

namespace Fylum.Api.Shared.JwtAuthentication
{
    public interface IJwtAuthService
    {
        string BuildToken(Guid userId);
        Guid? GetUserIdFromClaims(IEnumerable<Claim> claims);
    }
}