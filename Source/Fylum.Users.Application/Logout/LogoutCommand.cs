using Fylum.Application;

namespace Fylum.Users.Application.Logout;

public record LogoutCommand(Guid RefreshId, Guid UserId) : ICommand;
