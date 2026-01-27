namespace Fylum.Client.Auth.Token.Storage;

public interface ITokenStorage
{
    Task<TokenPair?> GetTokenPairAsync();
    Task StoreTokenPairAsync(TokenPair tokenPair);
    Task ClearTokenPairAsync();
}
