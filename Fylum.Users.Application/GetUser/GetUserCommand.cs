using Fylum.Application;
using Fylum.Users.Domain;

namespace Fylum.Users.Application.GetUser;

public record GetUserCommand(Guid UserId) : ICommand<User>
{
}