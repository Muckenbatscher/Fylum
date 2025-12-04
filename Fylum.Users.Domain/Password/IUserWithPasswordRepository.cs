namespace Fylum.Users.Domain.Password;

public interface IUserWithPasswordRepository
{
    UserWithPasswordLogin? GetByUsername(string username);

    void Create(UserWithPasswordLogin userWithPasswordLogin);
}