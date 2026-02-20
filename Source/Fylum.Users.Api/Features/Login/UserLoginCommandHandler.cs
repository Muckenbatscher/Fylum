using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Core.Domain;
using Fylum.Users.Api.Common.Domain;
using Fylum.Users.Api.Common.Domain.Password;
using Fylum.Users.Api.Common.Domain.RefreshToken;
using Fylum.Users.Api.Features.RefreshAccessToken;
using Fylum.Users.SharedModels;
using Microsoft.Extensions.Options;

namespace Fylum.Users.Api.Features.Login;

public class UserLoginCommandHandler : IUserLoginCommandHandler
{
    private readonly IUnitOfWorkFactory<LoginUnitOfWork> _loginUnitOfWorkFactory;
    private readonly IPasswordLoginVerification _loginVerification;
    private readonly RefreshTokenOptions _refreshTokenOptions;
    private readonly IMapper<User, UserDto> _userMapper;

    public UserLoginCommandHandler(IUnitOfWorkFactory<LoginUnitOfWork> loginUnitOfWorkFactory,
        IPasswordLoginVerification loginVerification,
        IOptions<RefreshTokenOptions> refreshTokenOptions,
        IMapper<User, UserDto> userMapper)
    {
        _loginUnitOfWorkFactory = loginUnitOfWorkFactory;
        _loginVerification = loginVerification;
        _refreshTokenOptions = refreshTokenOptions.Value;
        _userMapper = userMapper;
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

        var userDto = _userMapper.Map(userLogin.User);
        return new UserLoginResult(userDto, refreshToken.Id, refreshToken.ExpiresAt);
    }
}