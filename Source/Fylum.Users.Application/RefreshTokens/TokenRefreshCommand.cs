using Fylum.Application;

namespace Fylum.Users.Application.RefreshTokens;

public record TokenRefreshCommand(Guid UserId, Guid TokenRefreshId) : ICommand<TokenRefreshResult>
{
}