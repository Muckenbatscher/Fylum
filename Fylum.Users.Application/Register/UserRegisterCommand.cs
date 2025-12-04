using Fylum.Application;

namespace Fylum.Users.Application.Register;

public record UserRegisterCommand(string Username, string Password) : ICommand<UserRegisterResult>
{
}