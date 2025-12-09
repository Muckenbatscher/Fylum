using Fylum.Client.Auth;

namespace Fylum.Client.Demo;

public class App
{
    private readonly ITokenService _tokenService;
    private readonly IFylumClient _fylumClient;

    // Constructor Injection: Der ServiceProvider füllt diese Variable automatisch!
    public App(ITokenService tokenService, IFylumClient fylumClient)
    {
        _tokenService = tokenService;
        _fylumClient = fylumClient;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        Console.WriteLine("App gestartet...");
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();

        await _tokenService.LoginAsync(username!, password!, cancellationToken);
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

        Console.WriteLine("App beendet.");
    }
}
