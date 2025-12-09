using Fylum.Users.Api.Shared;
using System.Net.Http.Json;

namespace Fylum.Client.Auth;

internal class AuthService
{
    private readonly ITokenStorage _storage;
    private readonly HttpClient _authClient; // Separate client just for auth calls
    private readonly SemaphoreSlim _refreshTokenLock = new(1, 1); // Thread safety lock

    public AuthService(ITokenStorage storage, IHttpClientFactory factory)
    {
        _storage = storage;
        // use a clean client to avoid infinite loops in the handler
        _authClient = factory.CreateClient("AuthClient");
    }

    public async Task<string?> GetAccessTokenAsync()
    {
        var tokens = await _storage.GetTokenPairAsync();
        return tokens.AccessToken;
    }

    public async Task LoginAsync(string username, string password)
    {
        var loginRequest = new LoginRequest(username, password);
        var loginResponse = await _authClient.PostAsync(EndpointRoutes.LoginRoute, JsonContent.Create(loginRequest));
        if (!loginResponse.IsSuccessStatusCode)
            throw new Exception("Login failed");

        var loginResult = await loginResponse.Content.ReadFromJsonAsync<LoginResponse>()
            ?? throw new Exception("Invalid login response");

        var tokenPair = new TokenPair(loginResult.AccessToken, loginResult.RefreshToken);
        await _storage.StoreTokenPairAsync(tokenPair);
    }

    public async Task<string?> RefreshTokenAsync()
    {
        // 1. Wait for the lock
        await _refreshTokenLock.WaitAsync();
        try
        {
            // 2. Double-check: Did someone else refresh it while we were waiting?
            var tokenPair = await _storage.GetTokenPairAsync();
            // In a real app, you might check if 'currentAccess' is actually new/valid here.

            if (string.IsNullOrEmpty(tokenPair.RefreshToken))
                return null;

            // 3. Perform the actual API call to refresh
            // var response = await _authClient.PostAsync("/refresh", new { token = currentRefresh });

            // If refresh fails (e.g., refresh token expired), clear everything
            // await _storage.ClearTokensAsync(); return null;

            // 4. Save new tokens
            var newAccess = "refreshed_access_token";
            var newRefresh = "refreshed_refresh_token";
            var newTokenPair = new TokenPair(newAccess, newRefresh);
            await _storage.StoreTokenPairAsync(newTokenPair);

            return newAccess;
        }
        finally
        {
            _refreshTokenLock.Release();
        }
    }
}