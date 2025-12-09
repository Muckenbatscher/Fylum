
namespace Fylum.Client.Auth;

public interface ITokenService
{
    Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken);
    Task LoginAsync(string username, string password, CancellationToken cancellationToken);
    Task RefreshTokenAsync(CancellationToken cancellationToken);
}
