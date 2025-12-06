namespace Fylum.Users.Postgres;

internal class RefreshTokenQueryModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset IssuedAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
}
