using Fylum.Users.Api.Shared;

namespace Fylum.Client.Auth;

public interface IRefreshTokenClient
{
    Task<TokenRefreshResponse> RefreshToken(CancellationToken cancellationToken);
}
