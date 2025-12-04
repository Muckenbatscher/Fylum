namespace Fylum.Users.Domain.Password;

public interface IPasswordLoginVerification
{
    bool VerifyPasswordLogin(string password, PasswordLogin login);
}