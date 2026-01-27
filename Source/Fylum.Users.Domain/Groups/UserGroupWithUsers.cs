namespace Fylum.Users.Domain.Groups;

public class UserGroupWithUsers
{
    public UserGroupWithUsers(UserGroup group, IEnumerable<User> users)
    {
        Group = group;
        _users = users.ToList();
    }

    public UserGroup Group { get; }
    public IEnumerable<User> Users => _users.AsReadOnly();
    private readonly List<User> _users;

    public static UserGroupWithUsers Create(UserGroup group, IEnumerable<User> users)
        => new UserGroupWithUsers(group, users);

    public void AddUser(User user)
    {
        if (!_users.Any(u => u.Id == user.Id))
            _users.Add(user);
    }
    public void RemoveUser(Guid userId)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == userId);
        if (existingUser != null)
            _users.Remove(existingUser);
    }
}