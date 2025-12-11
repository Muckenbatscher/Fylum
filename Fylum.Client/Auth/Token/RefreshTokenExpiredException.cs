namespace Fylum.Client.Auth.Token;

public class RefreshTokenExpiredException : Exception
{
    public RefreshTokenExpiredException() : base("Refresh token is expired. Explicitly Login again first.")
    {
    }
}
