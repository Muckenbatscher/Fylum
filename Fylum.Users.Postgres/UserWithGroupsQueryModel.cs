namespace Fylum.Users.Postgres;

internal class UserWithGroupsQueryModel
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public Guid? UserGroupId { get; set; }
    public string? UserGroupName { get; set; }
}