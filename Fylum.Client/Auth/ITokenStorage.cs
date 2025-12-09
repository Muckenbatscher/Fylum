namespace Fylum.Client.Auth;

public interface ITokenStorage
{
    Task<TokenPair?> GetTokenPairAsync();
    Task StoreTokenPairAsync(TokenPair tokenPair);
    Task ClearTokenPair();
}
