using Fylum.Core.Application.Command;

namespace Fylum.Users.Api.Features.Logout;

public interface ILogoutCommandHandler : ICommandHandler<LogoutCommand>
{
}
