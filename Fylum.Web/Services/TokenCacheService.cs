using Fylum.Client.Auth.Token.Storage;

namespace Fylum.Web.Services;

public class TokenCacheService : ITokenCacheService
{
    public TokenCacheService()
    {
        Id = Guid.NewGuid();
        Console.WriteLine($"TokenCacheService created with Id: {Id}");
    }
    public Guid Id { get; }
    public TokenPair? CachedToken { get; set; }
}
