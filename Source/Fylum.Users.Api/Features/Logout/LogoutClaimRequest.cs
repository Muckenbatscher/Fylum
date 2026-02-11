using FastEndpoints;
using Fylum.Core.Presentation.Api.JwtAuthentication;

namespace Fylum.Users.Api.Features.Logout;

public class LogoutClaimRequest
{
    [FromClaim(JwtAuthConstants.RefreshIdClaim)]
    public Guid RefreshId { get; set; }

    [FromClaim(JwtAuthConstants.RefreshUserIdClaim)]
    public Guid UserId { get; set; }
}