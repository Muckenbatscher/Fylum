using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

public class TokenRefreshClaimRequest
{
    [FromClaim(JwtAuthConstants.RefreshIdClaim)]
    public Guid RefreshId { get; set; }

    [FromClaim(JwtAuthConstants.RefreshUserIdClaim)]
    public Guid UserId { get; set; }
}