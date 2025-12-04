using Fylum.Application;

namespace Fylum.Users.Application.TokenRefresh;

public interface ITokenRefreshCommandHandler : ICommandHandler<TokenRefreshCommand, TokenRefreshResult>
{
}