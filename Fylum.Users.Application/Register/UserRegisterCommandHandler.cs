using Fylum.Application;
using Fylum.Users.Application.RefreshTokens;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.RefreshTokens;
using Fylum.Users.Domain.Register;
using Microsoft.Extensions.Options;

namespace Fylum.Users.Application.Register;

public class UserRegisterCommandHandler : ICommandHandler<UserRegisterCommand, UserRegisterResult>
{
    private readonly IUserRegisterUnitOfWorkFactory _unitOfWorkFactory;
    private readonly IPasswordHashCalculator _hashCalculator;
    private readonly RefreshTokenOptions _refreshTokenOptions;

    public UserRegisterCommandHandler(IUserRegisterUnitOfWorkFactory unitOfWorkFactory,
        IPasswordHashCalculator hashCalculator,
        IOptions<RefreshTokenOptions> refreshTokenOptions)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _hashCalculator = hashCalculator;
        _refreshTokenOptions = refreshTokenOptions.Value;
    }

    public Result<UserRegisterResult> Handle(UserRegisterCommand command)
    {
        using var unitOfWork = _unitOfWorkFactory.Create();

        var userloginRepository = unitOfWork.UserWithPasswordRepository;
        var existingUser = userloginRepository.GetByUsername(command.Username);
        if (existingUser != null)
            return Result.Failure<UserRegisterResult>(Error.Conflict);

        var salt = _hashCalculator.CreateRandomSalt();
        var passwordHash = _hashCalculator.Hash(command.Password, salt);
        var userLogin = UserWithPasswordLogin.CreateNew(command.Username, true, passwordHash, salt);
        userloginRepository.Create(userLogin);

        var refreshToken = RefreshToken.IssueNew(userLogin.User.Id, _refreshTokenOptions.RefreshTokenExpiration);
        unitOfWork.RefreshTokenRepository.Add(refreshToken);

        unitOfWork.Commit();
        return new UserRegisterResult(userLogin.User.Id, refreshToken.Id, refreshToken.ExpiresAt);
    }
}