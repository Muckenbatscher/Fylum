using Fylum.Users.Api.Common.Application.PasswordHash;
using Fylum.Users.Api.Common.Domain.Password;

namespace Fylum.Users.Api.Features.Login;

public class PasswordLoginVerification : IPasswordLoginVerification
{
    private readonly IPasswordHashCalculator _passwordHashCalculator;

    public PasswordLoginVerification(IPasswordHashCalculator passwordHashCalculator)
    {
        _passwordHashCalculator = passwordHashCalculator;
    }

    public bool VerifyPasswordLogin(string password, PasswordLogin login)
    {
        bool verified = _passwordHashCalculator.Verify(password, login.PasswordHash, login.Salt);
        return verified;
    }
}