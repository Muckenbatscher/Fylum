using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Core.Domain;
using Fylum.Users.Api.Common.Domain;
using Fylum.Users.Api.Common.Domain.RefreshToken;
using Fylum.Users.SharedModels;
using Microsoft.Extensions.Options;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

public class TokenRefreshCommandHandler : ITokenRefreshCommandHandler
{
    private readonly IUnitOfWorkFactory<RefreshTokenUnitOfWork> _unitOfWorkFactory;
    private readonly RefreshTokenOptions _refreshTokenOptions;
    private readonly IMapper<User, UserDto> _userMapper;

    public TokenRefreshCommandHandler(IUnitOfWorkFactory<RefreshTokenUnitOfWork> unitOfWorkFactory,
        IOptions<RefreshTokenOptions> refreshTokenOptions,
        IMapper<User, UserDto> userMapper)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _refreshTokenOptions = refreshTokenOptions.Value;
        _userMapper = userMapper;
    }

    public Result<TokenRefreshResult> Handle(TokenRefreshCommand command)
    {
        var unitOfWork = _unitOfWorkFactory.Create();
        var refreshTokenRepository = unitOfWork.RefreshTokenRepository;
        var userRepository = unitOfWork.UserRepository;

        var oldToken = refreshTokenRepository.GetById(command.TokenRefreshId);
        if (oldToken is null)
            return Result.Failure(Error.NotFound);
        if (oldToken.UserId != command.UserId || !oldToken.IsValid)
            return Result.Failure(Error.Unauthorized);
        var user = userRepository.GetById(command.UserId);
        if (user is null || !user.IsActive)
            return Result.Failure(Error.Unauthorized);

        oldToken.Invalidate();
        refreshTokenRepository.Update(oldToken);

        var newToken = RefreshToken.IssueNew(command.UserId, _refreshTokenOptions.RefreshTokenExpiration);
        refreshTokenRepository.Add(newToken);

        unitOfWork.Commit();

        var userDto = _userMapper.Map(user);
        var refreshResult = new TokenRefreshResult(userDto, newToken.Id, newToken.ExpiresAt);
        return refreshResult;
    }
}