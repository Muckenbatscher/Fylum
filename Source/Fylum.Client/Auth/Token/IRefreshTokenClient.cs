using Fylum.Users.Api.Models;

namespace Fylum.Client.Auth.Token;

public interface IRefreshTokenClient
{
    Task<TokenRefreshResponse> RefreshTokenAsync(CancellationToken cancellationToken);
    Task<TokenRefreshResponse> RefreshTokenAsync();
    Task LogoutAsync(CancellationToken cancellationToken);
    Task LogoutAsync();
}
