using Fylum.Migrations.Api.PerformingAuthentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Fylum.Migrations.Api;

public class MigrationKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IPerformingKeyRequestValidator _requestKeyValidator;

    public MigrationKeyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IPerformingKeyRequestValidator requestKeyValidator)
        : base(options, logger, encoder)
    {
        _requestKeyValidator = requestKeyValidator;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var isAuthenticated = _requestKeyValidator.IsAuthenticated(Request);
        return isAuthenticated
            ? CreateSuccessResult()
            : AuthenticateResult.Fail("Invalid API Key");
    }

    private AuthenticateResult CreateSuccessResult()
    {
        Claim[] claims = [];
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}
