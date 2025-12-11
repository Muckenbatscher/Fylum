using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Fylum.Client.Auth.Token.Expiration;

public class TokenExpirationValidator : ITokenExpirationValidator
{
    private readonly ILogger<TokenExpirationValidator> _logger;

    public TokenExpirationValidator(ILogger<TokenExpirationValidator> logger)
    {
        _logger = logger;
    }

    public bool IsTokenExpired(string jwtString)
    {
        var handler = new JsonWebTokenHandler();
        if (!handler.CanReadToken(jwtString))
        {
            _logger.Log(LogLevel.Error, "The string is not a valid JWT format.");
            return true; // Treat as expired or invalid if it can't be read
        }
        var token = handler.ReadJsonWebToken(jwtString);

        var expiration = GetDateTimeOffsetFromTokenClaim(token, "exp");
        if (expiration == null)
        {
            _logger.Log(LogLevel.Warning, "JWT does not contain an 'exp' claim of correct format.");
            return true;
        }
        var notBefore = GetDateTimeOffsetFromTokenClaim(token, "nbf");
        if (notBefore == null)
            _logger.Log(LogLevel.Debug, "JWT does not contain an 'nbf' claim of correct format.");

        var expired = expiration < DateTimeOffset.UtcNow;
        var isUsedBefore = notBefore != null && notBefore > DateTimeOffset.UtcNow;
        var outsideValidPeriod = expired || isUsedBefore;
        return outsideValidPeriod;
    }

    private static DateTimeOffset? GetDateTimeOffsetFromTokenClaim(JsonWebToken token, string claimName)
    {
        var claimValue = GetValueFromTokenClaim(token, claimName);
        return long.TryParse(claimValue, out long unixTimeSeconds)
            ? DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds)
            : null;
    }
    private static string? GetValueFromTokenClaim(JsonWebToken token, string claimName)
    {
        var claim = token.Claims.FirstOrDefault(c => c.Type == claimName);
        return claim?.Value;
    }
}
