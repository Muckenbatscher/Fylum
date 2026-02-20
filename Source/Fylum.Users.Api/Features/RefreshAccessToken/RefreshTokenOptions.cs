namespace Fylum.Users.Api.Features.RefreshAccessToken;

public class RefreshTokenOptions
{
    public int RefreshTokenExpirationInDays { get; set; }
    public TimeSpan RefreshTokenExpiration => TimeSpan.FromDays(RefreshTokenExpirationInDays);
}