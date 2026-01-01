using Fylum.Client.Auth.Token.Storage;

namespace Fylum.Web.Services;

public class TokenCacheService : ITokenCacheService
{
    public TokenPair? CachedToken { get; set; }
}
