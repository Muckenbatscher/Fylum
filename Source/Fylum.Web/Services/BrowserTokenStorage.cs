using Fylum.Client.Auth.Token.Storage;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Fylum.Web.Services;

public class BrowserTokenStorage : IBrowserTokenStorage
{
    private readonly ITokenCacheService _tokenCache;
    private readonly ProtectedLocalStorage _localStorage;
    private const string AccessTokenStorageKey = "fylum_access_token";
    private const string RefreshTokenStorageKey = "fylum_refresh_token";

    public BrowserTokenStorage(ITokenCacheService tokenCache,
        ProtectedLocalStorage localStorage)
    {
        _tokenCache = tokenCache;
        _localStorage = localStorage;
    }

    public async Task LoadFromStorageAsync()
    {
        if (_tokenCache.CachedToken != null)
            return;

        try
        {
            var accessTokenResult = await _localStorage.GetAsync<string>(AccessTokenStorageKey);
            if (!accessTokenResult.Success)
                return;
            var refreshTokenResult = await _localStorage.GetAsync<string>(RefreshTokenStorageKey);
            if (!refreshTokenResult.Success)
                return;

            var tokenPair = new TokenPair(
                accessTokenResult.Value!,
                refreshTokenResult.Value!);
            _tokenCache.CachedToken = tokenPair;
        }
        catch
        {
            // Prerendering on the server. No JS available yet.
        }
    }

    public async Task<TokenPair?> GetTokenPairAsync()
    {
        return _tokenCache.CachedToken;
    }

    public async Task StoreTokenPairAsync(TokenPair tokenPair)
    {
        _tokenCache.CachedToken = tokenPair;

        try
        {
            await _localStorage.SetAsync(AccessTokenStorageKey, tokenPair.AccessToken);
            await _localStorage.SetAsync(RefreshTokenStorageKey, tokenPair.RefreshToken);
        }
        catch (InvalidOperationException)
        {
            // Prerendering on the server. No JS available yet.
        }
    }

    public async Task ClearTokenPairAsync()
    {
        _tokenCache.CachedToken = null;
        try
        {
            await _localStorage.DeleteAsync(AccessTokenStorageKey);
            await _localStorage.DeleteAsync(RefreshTokenStorageKey);
        }
        catch (InvalidOperationException)
        {
            // Prerendering on the server. No JS available yet.
        }
    }
}