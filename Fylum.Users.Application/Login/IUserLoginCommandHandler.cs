using Fylum.Application;

namespace Fylum.Users.Application.Login;

public interface IUserLoginCommandHandler : ICommandHandler<UserLoginCommand, UserLoginResult>
{
}