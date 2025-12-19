namespace Fylum.Client.Auth.Token;

public interface ITokenService
{
    Task<string?> GetAccessTokenAsync();

    Task LoginAsync(string username, string password, CancellationToken cancellationToken);
    Task LoginAsync(string username, string password);

    Task LogoutAsync(CancellationToken cancellationToken);
    Task LogoutAsync();

    Task RefreshTokenAsync(CancellationToken cancellationToken);
    Task RefreshTokenAsync();
}
