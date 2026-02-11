using Fylum.Application;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

public record TokenRefreshCommand(Guid UserId, Guid TokenRefreshId) : ICommand<TokenRefreshResult>
{
}