using Fylum.Core.Application.Command;
using Fylum.Core.Application.Results;
using Fylum.Core.Domain;
using Fylum.Users.Api.Common.Application.PasswordHash;
using Fylum.Users.Api.Common.Domain.Password;
using Fylum.Users.Api.Common.Domain.RefreshToken;
using Fylum.Users.Api.Features.RefreshAccessToken;
using Microsoft.Extensions.Options;

namespace Fylum.Users.Api.Features.Register;

public class UserRegisterCommandHandler : ICommandHandler<UserRegisterCommand, UserRegisterResult>
{
    private readonly IUnitOfWorkFactory<UserRegisterUnitOfWork> _unitOfWorkFactory;
    private readonly IPasswordHashCalculator _hashCalculator;
    private readonly RefreshTokenOptions _refreshTokenOptions;

    public UserRegisterCommandHandler(IUnitOfWorkFactory<UserRegisterUnitOfWork> unitOfWorkFactory,
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