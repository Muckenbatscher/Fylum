using Fylum.Users.Api.Shared;

namespace Fylum.Client.Auth;

public interface IAuthClient
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken);
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);

    Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken);
    Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
}
