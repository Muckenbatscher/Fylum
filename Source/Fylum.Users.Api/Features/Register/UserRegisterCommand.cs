using Fylum.Application;

namespace Fylum.Users.Api.Features.Register;

public record UserRegisterCommand(string Username, string Password) : ICommand<UserRegisterResult>
{
}