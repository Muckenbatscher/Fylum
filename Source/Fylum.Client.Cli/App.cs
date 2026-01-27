using Fylum.Client.Auth.Token;

namespace Fylum.Client.Cli;

public class App
{
    private readonly ITokenService _tokenService;

    public App(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        Console.WriteLine("App started...");

        Console.Write("Username: ");
        var usernameRead = Console.ReadLine();
        var username = string.IsNullOrEmpty(usernameRead) ? "admin" : usernameRead;
        Console.Write("Password: ");
        var passwordRead = Console.ReadLine();
        var password = string.IsNullOrEmpty(passwordRead) ? "admin" : passwordRead;

        await _tokenService.LoginAsync(username, password, cancellationToken);
        Console.WriteLine("Login successful!");

        await _tokenService.LogoutAsync(cancellationToken);
    }
}
