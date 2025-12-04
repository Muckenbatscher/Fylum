using Fylum.Domain;

namespace Fylum.Users.Domain.Groups;

public class UserGroup : IdentifiableEntity<Guid>
{
    private const string AdminGroupId = "FF7CFB5F-137F-42E0-A857-4E498A7B4E65";

    private UserGroup(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; }

    public bool IsAdmin => Id.Equals(Guid.Parse(AdminGroupId));

    public static UserGroup Create(Guid id, string name)
        => new UserGroup(id, name);

    public static UserGroup CreateNew(string name)
        => new UserGroup(Guid.NewGuid(), name);
}