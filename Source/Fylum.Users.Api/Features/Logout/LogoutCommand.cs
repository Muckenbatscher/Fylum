using Fylum.Application;

namespace Fylum.Users.Api.Features.Logout;

public record LogoutCommand(Guid RefreshId, Guid UserId) : ICommand;
