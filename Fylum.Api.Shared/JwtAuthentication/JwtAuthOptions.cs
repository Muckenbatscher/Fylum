namespace Fylum.Api.Shared.JwtAuthentication
{
    public class JwtAuthOptions
    {
        public string UserIdClaim { get; set; }
        public string SigningKey { get; set; }
        public int ExpirationInMinutes { get; set; }
        public TimeSpan Expiration { get => TimeSpan.FromMinutes(ExpirationInMinutes); }
    }
}
