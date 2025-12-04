using Fylum.Application;

namespace Fylum.Users.Application.TokenRefresh;

public class TokenRefreshCommandHandler : ITokenRefreshCommandHandler
{
    public Result<TokenRefreshResult> Handle(TokenRefreshCommand command)
    {
        var refreshResult = new TokenRefreshResult(command.UserId, Guid.NewGuid());
        return refreshResult;
    }
}