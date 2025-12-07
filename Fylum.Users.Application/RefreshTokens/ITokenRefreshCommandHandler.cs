using Fylum.Application;

namespace Fylum.Users.Application.RefreshTokens;

public interface ITokenRefreshCommandHandler : ICommandHandler<TokenRefreshCommand, TokenRefreshResult>
{
}