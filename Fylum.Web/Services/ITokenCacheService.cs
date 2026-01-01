using Fylum.Client.Auth.Token.Storage;

namespace Fylum.Web.Services;

public interface ITokenCacheService
{
    public TokenPair? CachedToken { get; set; }
}
