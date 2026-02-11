namespace Fylum.Users.Api.Common.Domain.Password;

public interface IPasswordLoginVerification
{
    bool VerifyPasswordLogin(string password, PasswordLogin login);
}