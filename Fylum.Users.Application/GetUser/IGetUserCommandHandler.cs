using Fylum.Application;
using Fylum.Users.Domain;

namespace Fylum.Users.Application.GetUser;

public interface IGetUserCommandHandler : ICommandHandler<GetUserCommand, User>
{
}