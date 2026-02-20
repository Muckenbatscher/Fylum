using FastEndpoints;
using Fylum.Core.Presentation.Api.JwtAuthentication;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

public class TokenRefreshClaimRequest
{
    [FromClaim(JwtAuthConstants.RefreshIdClaim)]
    public Guid RefreshId { get; set; }

    [FromClaim(JwtAuthConstants.RefreshUserIdClaim)]
    public Guid UserId { get; set; }
}