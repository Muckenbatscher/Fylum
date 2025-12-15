using Fylum.Client.Auth.Token.Expiration;
using Fylum.Client.Auth.Token.Storage;
using Fylum.Users.Api.Shared;

namespace Fylum.Client.Auth.Token;

public class TokenService : ITokenService
{
    private readonly ITokenStorage _storage;
    private readonly ITokenExpirationValidator _tokenExpirationValidator;
    private readonly IAuthClient _authClient;
    private readonly IRefreshTokenClient _refreshTokenClient;

    private readonly SemaphoreSlim _refreshTokenLock = new(1, 1); // Thread safety lock

    public TokenService(ITokenStorage storage,
        ITokenExpirationValidator tokenExpirationValidator,
        IAuthClient authClient,
        IRefreshTokenClient refreshTokenClient)
    {
        _storage = storage;
        _tokenExpirationValidator = tokenExpirationValidator;
        _authClient = authClient;
        _refreshTokenClient = refreshTokenClient;
    }

    public async Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken)
    {
        var tokens = await _storage.GetTokenPairAsync();
        return tokens?.AccessToken;
    }

    public async Task LoginAsync(string username, string password, CancellationToken cancellationToken)
    {
        var loginRequest = new LoginRequest(username, password);
        var loginResult = await _authClient.LoginAsync(loginRequest, cancellationToken);

        var tokenPair = new TokenPair(loginResult.AccessToken, loginResult.RefreshToken);
        await _storage.StoreTokenPairAsync(tokenPair);
    }
    public async Task LogoutAsync(CancellationToken cancellationToken)
    {
        var tokenPair = await _storage.GetTokenPairAsync();
        if (tokenPair == null || string.IsNullOrEmpty(tokenPair.RefreshToken))
            throw new InitialLoginMissingException();

        await _refreshTokenClient.LogoutAsync(cancellationToken);
        await _storage.ClearTokenPairAsync();
    }

    public async Task RefreshTokenAsync(CancellationToken cancellationToken)
    {
        await _refreshTokenLock.WaitAsync(cancellationToken);
        try
        {
            var tokenPair = await _storage.GetTokenPairAsync();
            if (tokenPair == null || string.IsNullOrEmpty(tokenPair.RefreshToken))
                throw new InitialLoginMissingException();
            if (_tokenExpirationValidator.IsTokenExpired(tokenPair.RefreshToken))
                throw new RefreshTokenExpiredException();

            var refreshResult = await _refreshTokenClient.RefreshTokenAsync(cancellationToken);

            var newTokenPair = new TokenPair(
                refreshResult.AccessToken, refreshResult.RefreshToken);
            await _storage.StoreTokenPairAsync(newTokenPair);
        }
        finally
        {
            _refreshTokenLock.Release();
        }
    }
}