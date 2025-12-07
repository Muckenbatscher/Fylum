namespace Fylum.Users.Application.RefreshTokens;

public class RefreshTokenOptions
{
    public int RefreshTokenExpirationInDays { get; set; }
    public TimeSpan RefreshTokenExpiration => TimeSpan.FromDays(RefreshTokenExpirationInDays);
}