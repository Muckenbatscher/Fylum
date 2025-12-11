namespace Fylum.Client.Auth.Token.Expiration;

public interface ITokenExpirationValidator
{
    bool IsTokenExpired(string token);
}
