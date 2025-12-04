using Fylum.Application;

namespace Fylum.Users.Application.Login;

public record UserLoginCommand(string Username, string Password) :
    ICommand<UserLoginResult>;