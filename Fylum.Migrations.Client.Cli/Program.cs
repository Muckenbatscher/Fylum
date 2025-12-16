using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fylum.Migrations.Client.Cli;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteInColor("Migrations Client CLI", ConsoleColor.Magenta);
        Console.WriteLine();

        Console.Write("BaseUrl: ");
        var baseUrl = Console.ReadLine()!;
        Console.Write("PerformingKey: ");
        var performingKey = Console.ReadLine()!;

        var builder = Host.CreateApplicationBuilder(args);
        ConfigureServices(builder.Services, baseUrl, performingKey);

        var host = builder.Build();
        try
        {
            var app = host.Services.GetRequiredService<App>();
            await app.Run(CancellationToken.None);
        }
        catch (Exception ex)
        {
            Console.WriteInColor($"An error occurred: {ex.Message}", ConsoleColor.Red);
            Console.WriteLine();
        }
        finally
        {
            if (host.Services is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
        Console.ReadLine();
    }

    private static void ConfigureServices(IServiceCollection services, string baseUrl, string performingKey)
    {
        services.AddTransient<App>();

        services.AddMigrationClient(options =>
        {
            options.BaseUri = new Uri(baseUrl);
            options.MigrationPerformingKey = performingKey;
            options.Timeout = TimeSpan.FromSeconds(60);
        });
    }
}
