namespace Fylum.Users.Domain.Groups;

public class UserWithGroups
{
    private UserWithGroups(User user, IEnumerable<UserGroup> groups)
    {
        User = user;
        _userGroups = groups.ToList();
    }

    public User User { get; }
    public IEnumerable<UserGroup> Groups => _userGroups.AsReadOnly();
    private readonly List<UserGroup> _userGroups;

    public static UserWithGroups Create(User user, IEnumerable<UserGroup> groups)
        => new UserWithGroups(user, groups);

    public void AddToGroup(UserGroup group)
    {
        if (!_userGroups.Any(g => g.Id == group.Id))
            _userGroups.Add(group);
    }
    public void RemoveFromGroup(Guid groupId)
    {
        var existingGroup = _userGroups.FirstOrDefault(g => g.Id == groupId);
        if (existingGroup != null)
            _userGroups.Remove(existingGroup);
    }
}