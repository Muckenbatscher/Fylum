namespace Fylum.Users.Api.Common.Application.PasswordHash;

public interface IPasswordHashCalculator
{
    string CreateRandomSalt();
    string Hash(string password, string salt);

    bool Verify(string password, string hash, string salt);
}