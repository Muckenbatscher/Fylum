namespace Fylum.Users.Domain.Password;

public class UserWithPasswordLogin
{
    private UserWithPasswordLogin(User user, PasswordLogin login)
    {
        User = user;
        Login = login;
    }

    public User User { get; init; }
    public PasswordLogin Login { get; private set; }

    public static UserWithPasswordLogin Create(Guid userId, string username, bool isActive, string passwordHash, string salt)
    {
        var user = User.Create(userId, username, isActive);
        var login = PasswordLogin.Create(passwordHash, salt);
        return new UserWithPasswordLogin(user, login);
    }
    public static UserWithPasswordLogin CreateNew(string username, bool isActive, string passwordHash, string salt)
    {
        var user = User.CreateNew(username, isActive);
        var login = PasswordLogin.Create(passwordHash, salt);
        return new UserWithPasswordLogin(user, login);
    }

    public void UpdatePasswordLogin(string newPasswordHash, string newSalt)
    {
        Login = PasswordLogin.Create(newPasswordHash, newSalt);
    }
}