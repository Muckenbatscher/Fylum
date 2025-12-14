using Fylum.Users.Api.Shared;

namespace Fylum.Client.Auth.Token;

public interface IRefreshTokenClient
{
    Task<TokenRefreshResponse> RefreshToken(CancellationToken cancellationToken);
}
