namespace Fylum.Users.Postgres;

internal class UserQueryModel
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}