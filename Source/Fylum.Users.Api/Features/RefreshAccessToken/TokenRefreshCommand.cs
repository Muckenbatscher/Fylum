using Fylum.Core.Application.Command;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

public record TokenRefreshCommand(Guid UserId, Guid TokenRefreshId) : ICommand<TokenRefreshResult>
{
}