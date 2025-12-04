namespace Fylum.Users.Api.Shared;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}