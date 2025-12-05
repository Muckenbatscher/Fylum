using Fylum.Domain;

namespace Fylum.Users.Domain;

public class User : IdentifiableEntity<Guid>
{
    private User(Guid id, string username, bool isActive) : base(id)
    {
        Username = username;
        IsActive = isActive;
    }

    public string Username { get; private set; }
    public bool IsActive { get; private set; }

    public static User Create(Guid id, string username, bool isActive)
    {
        return new User(id, username, isActive);
    }
    public static User CreateNew(string username, bool isActive)
    {
        return new User(Guid.NewGuid(), username, isActive);
    }
}