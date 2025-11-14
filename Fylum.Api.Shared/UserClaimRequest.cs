using FastEndpoints;
using Fylum.Api.Shared.JwtAuthentication;

namespace Fylum.Api.Shared;

public class UserClaimRequest
{
    [FromClaim(JwtAuthConstants.UserIdClaim)]
    public Guid UserId { get; set; }
}
