using Fylum.Users.Api.Shared;
using System.Net.Http.Json;

namespace Fylum.Client.Auth;

public class AuthClient : IAuthClient
{
    private readonly HttpClient _httpClient;

    public AuthClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            EndpointRoutes.LoginRoute, loginRequest, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Login failed");
        var loginResult = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken)
            ?? throw new Exception("Invalid login response");
        return loginResult;
    }
    public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            EndpointRoutes.RegisterRoute, registerRequest, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Registering failed");
        var loginResult = await response.Content.ReadFromJsonAsync<RegisterResponse>(cancellationToken)
            ?? throw new Exception("Invalid register response");
        return loginResult;
    }
}
