using Fylum.Application;

namespace Fylum.Users.Application.TokenRefresh;

public record TokenRefreshCommand(Guid UserId, Guid TokenRefreshId) : ICommand<TokenRefreshResult>
{
}