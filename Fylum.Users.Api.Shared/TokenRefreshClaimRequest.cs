using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;

namespace Fylum.Users.Api.Shared;

public class TokenRefreshClaimRequest
{
    [FromClaim(JwtAuthConstants.RefreshIdClaim)]
    public Guid RefreshId { get; set; }

    [FromClaim(JwtAuthConstants.RefreshUserIdClaim)]
    public Guid UserId { get; set; }
}