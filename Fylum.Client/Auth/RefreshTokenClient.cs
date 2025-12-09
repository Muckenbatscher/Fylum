using Fylum.Users.Api.Shared;
using System.Net.Http.Json;

namespace Fylum.Client.Auth;

public class RefreshTokenClient : IRefreshTokenClient
{
    private readonly HttpClient _httpClient;

    public RefreshTokenClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TokenRefreshResponse> RefreshToken(CancellationToken cancellationToken)
    {
        var emptyContent = new StringContent(string.Empty);
        var response = await _httpClient.PostAsync(
            EndpointRoutes.TokenRefreshRoute, emptyContent, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Token refresh failed");
        var loginResult = await response.Content.ReadFromJsonAsync<TokenRefreshResponse>(cancellationToken)
            ?? throw new Exception("Invalid token refresh response");
        return loginResult;
    }
}
