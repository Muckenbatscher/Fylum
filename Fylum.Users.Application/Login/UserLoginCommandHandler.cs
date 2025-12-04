using Fylum.Application;
using Fylum.Users.Domain.Password;

namespace Fylum.Users.Application.Login;

public class UserLoginCommandHandler : IUserLoginCommandHandler
{
    private readonly IUserWithPasswordRepository _userWithPasswordRepository;
    private readonly IPasswordLoginVerification _loginVerification;

    public UserLoginCommandHandler(IUserWithPasswordRepository userWithPasswordRepository,
        IPasswordLoginVerification loginVerification)
    {
        _userWithPasswordRepository = userWithPasswordRepository;
        _loginVerification = loginVerification;
    }

    public Result<UserLoginResult> Handle(UserLoginCommand command)
    {
        var userLogin = _userWithPasswordRepository.GetByUsername(command.Username);
        if (userLogin == null)
            return Result.Failure<UserLoginResult>(Error.NotFound);
        if (!userLogin.User.IsActive)
            return Result.Failure<UserLoginResult>(Error.Unauthorized);

        bool passwordValid = _loginVerification.VerifyPasswordLogin(
            command.Password, userLogin.Login);

        if (!passwordValid)
            return Result.Failure<UserLoginResult>(Error.Unauthorized);

        //TODO: Store refresh token in database with expiry
        var refreshTokenId = Guid.NewGuid();
        return new UserLoginResult(userLogin.User.Id, refreshTokenId);
    }
}