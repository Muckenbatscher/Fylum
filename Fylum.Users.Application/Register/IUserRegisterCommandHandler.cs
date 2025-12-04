using Fylum.Application;

namespace Fylum.Users.Application.Register;

public interface IUserRegisterCommandHandler : ICommandHandler<UserRegisterCommand, UserRegisterResult>
{
}