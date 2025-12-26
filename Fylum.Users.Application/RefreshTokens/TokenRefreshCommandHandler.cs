using Fylum.Application;
using Fylum.Users.Domain.RefreshTokens;
using Microsoft.Extensions.Options;

namespace Fylum.Users.Application.RefreshTokens;

public class TokenRefreshCommandHandler : ICommandHandler<TokenRefreshCommand, TokenRefreshResult>
{
    private readonly IRefreshTokenUnitOfWorkFactory _unitOfWorkFactory;
    private readonly RefreshTokenOptions _refreshTokenOptions;

    public TokenRefreshCommandHandler(IRefreshTokenUnitOfWorkFactory unitOfWorkFactory,
        IOptions<RefreshTokenOptions> refreshTokenOptions)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _refreshTokenOptions = refreshTokenOptions.Value;
    }

    public Result<TokenRefreshResult> Handle(TokenRefreshCommand command)
    {
        var unitOfWork = _unitOfWorkFactory.Create();
        var refreshTokenRepository = unitOfWork.RefreshTokenRepository;

        var oldToken = refreshTokenRepository.GetById(command.TokenRefreshId);
        if (oldToken is null)
            return Result.Failure(Error.NotFound);
        if (oldToken.UserId != command.UserId || !oldToken.IsValid)
            return Result.Failure(Error.Unauthorized);

        oldToken.Invalidate();
        refreshTokenRepository.Update(oldToken);

        var newToken = RefreshToken.IssueNew(command.UserId, _refreshTokenOptions.RefreshTokenExpiration);
        refreshTokenRepository.Add(newToken);

        unitOfWork.Commit();

        var refreshResult = new TokenRefreshResult(command.UserId, newToken.Id, newToken.ExpiresAt);
        return refreshResult;
    }
}