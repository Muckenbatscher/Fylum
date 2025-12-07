namespace Fylum.Api.Shared.JwtAuthentication;

public class JwtAuthOptions
{
    public string SigningKey { get; set; } = string.Empty;
    public int AccessTokenExpirationInMinutes { get; set; }
    public TimeSpan AccessTokenExpiration => TimeSpan.FromMinutes(AccessTokenExpirationInMinutes);
}