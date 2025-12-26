using Fylum.Application;
using Fylum.Users.Application.RefreshTokens;
using Fylum.Users.Domain.Login;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.RefreshTokens;
using Microsoft.Extensions.Options;

namespace Fylum.Users.Application.Login;

public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand, UserLoginResult>
{
    private readonly ILoginUnitOfWorkFactory _loginUnitOfWorkFactory;
    private readonly IPasswordLoginVerification _loginVerification;
    private readonly RefreshTokenOptions _refreshTokenOptions;

    public UserLoginCommandHandler(ILoginUnitOfWorkFactory loginUnitOfWorkFactory,
        IPasswordLoginVerification loginVerification,
        IOptions<RefreshTokenOptions> refreshTokenOptions)
    {
        _loginUnitOfWorkFactory = loginUnitOfWorkFactory;
        _loginVerification = loginVerification;
        _refreshTokenOptions = refreshTokenOptions.Value;
    }

    public Result<UserLoginResult> Handle(UserLoginCommand command)
    {
        using var loginUnitOfWork = _loginUnitOfWorkFactory.Create();

        var userLogin = loginUnitOfWork.UserWithPasswordRepository
            .GetByUsername(command.Username);
        if (userLogin == null)
            return Result.Failure<UserLoginResult>(Error.NotFound);
        if (!userLogin.User.IsActive)
            return Result.Failure<UserLoginResult>(Error.Unauthorized);

        bool passwordValid = _loginVerification.VerifyPasswordLogin(
            command.Password, userLogin.Login);

        if (!passwordValid)
            return Result.Failure<UserLoginResult>(Error.Unauthorized);

        var refreshToken = RefreshToken.IssueNew(userLogin.User.Id, _refreshTokenOptions.RefreshTokenExpiration);
        loginUnitOfWork.RefreshTokenRepository.Add(refreshToken);

        loginUnitOfWork.Commit();

        return new UserLoginResult(userLogin.User.Id, refreshToken.Id, refreshToken.ExpiresAt);
    }
}