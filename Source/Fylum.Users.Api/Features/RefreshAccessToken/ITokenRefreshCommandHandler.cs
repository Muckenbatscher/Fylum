using Fylum.Core.Application.Command;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

public interface ITokenRefreshCommandHandler : ICommandHandler<TokenRefreshCommand, TokenRefreshResult>
{
}
