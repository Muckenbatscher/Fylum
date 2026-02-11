using FastEndpoints;

namespace Fylum.Core.Presentation.Api.JwtAuthentication;

public class UserClaimRequest
{
    [FromClaim(JwtAuthConstants.UserIdClaim)]
    public Guid UserId { get; set; }
}