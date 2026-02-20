using Fylum.Users.SharedModels.Login;
using Fylum.Users.SharedModels.Register;

namespace Fylum.Client.Auth;

public interface IAuthClient
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken);
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);

    Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken);
    Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
}
