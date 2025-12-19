using Fylum.Client.HttpMessaging;
using Fylum.Users.Api.Shared;
using System.Net.Http.Json;
using System.Text.Json;

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
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<LoginResponse>(responseContent, JsonSerializerOptions.Web)
            ?? throw new JsonParsingException<LoginResponse>(responseContent);
        return result;
    }
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest) => await LoginAsync(loginRequest, CancellationToken.None);

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            EndpointRoutes.RegisterRoute, registerRequest, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Registering failed");
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<RegisterResponse>(responseContent, JsonSerializerOptions.Web)
            ?? throw new JsonParsingException<RegisterResponse>(responseContent);
        return result;
    }
    public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest) => await RegisterAsync(registerRequest, CancellationToken.None);
}
