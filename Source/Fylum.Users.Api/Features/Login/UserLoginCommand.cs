using Fylum.Core.Application.Command;

namespace Fylum.Users.Api.Features.Login;

public record UserLoginCommand(string Username, string Password) :
    ICommand<UserLoginResult>;