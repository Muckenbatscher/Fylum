using Fylum.Application;

namespace Fylum.Users.Application.RefreshTokens;

public class TokenRefreshCommandHandler : ITokenRefreshCommandHandler
{
    public Result<TokenRefreshResult> Handle(TokenRefreshCommand command)
    {
        var refreshResult = new TokenRefreshResult(command.UserId, Guid.NewGuid());
        return refreshResult;
    }
}