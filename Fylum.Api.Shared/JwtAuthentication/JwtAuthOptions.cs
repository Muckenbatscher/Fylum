namespace Fylum.Api.Shared.JwtAuthentication;

public class JwtAuthOptions
{
    public string SigningKey { get; set; } = string.Empty;
    public int ExpirationInMinutes { get; set; }
    public TimeSpan Expiration { get => TimeSpan.FromMinutes(ExpirationInMinutes); }
}