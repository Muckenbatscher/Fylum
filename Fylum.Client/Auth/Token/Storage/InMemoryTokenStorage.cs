namespace Fylum.Client.Auth.Token.Storage;

public class InMemoryTokenStorage : ITokenStorage
{
    private TokenPair? _storedTokenPair;

    public async Task<TokenPair?> GetTokenPairAsync()
        => _storedTokenPair;

    public async Task StoreTokenPairAsync(TokenPair tokenPair)
        => _storedTokenPair = tokenPair;

    public async Task ClearTokenPairAsync()
        => _storedTokenPair = null;
}
