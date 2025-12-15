using Fylum.Client.Auth.Token;

namespace Fylum.Client.Demo;

public class App
{
    private readonly ITokenService _tokenService;
    private readonly IFylumClient _fylumClient;

    public App(ITokenService tokenService, IFylumClient fylumClient)
    {
        _tokenService = tokenService;
        _fylumClient = fylumClient;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        Console.WriteLine("App gestartet...");
        Console.Write("Username: ");
        var usernameRead = Console.ReadLine();
        var username = string.IsNullOrEmpty(usernameRead) ? "admin" : usernameRead;
        Console.Write("Password: ");
        var passwordRead = Console.ReadLine();
        var password = string.IsNullOrEmpty(passwordRead) ? "admin" : passwordRead;

        await _tokenService.LoginAsync(username, password, cancellationToken);
        Console.WriteLine("Login erfolgreich!");

        var parsed = true;
        while (parsed)
        {
            Console.Write("File ID: ");
            parsed = Guid.TryParse(Console.ReadLine()!, out Guid fileId);
            if (!parsed)
                break;

            var file = await _fylumClient.GetById(fileId, cancellationToken);
            Console.WriteLine($"file found: {file.Name} (latest revision: {file.LatestRevisionId})");
        }
        await _tokenService.LogoutAsync(cancellationToken);

        Console.WriteLine("App beendet.");
    }
}
