using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fylum.Client.Cli;

internal class Program
{
    static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (s, e) =>
        {
            Console.WriteLine("Canceling...");
            cts.Cancel();
            e.Cancel = true;
        };

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Fylum Client CLI");
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("BaseUrl: ");
        var baseUrl = Console.ReadLine()!;

        var builder = Host.CreateApplicationBuilder(args);
        ConfigureServices(builder.Services, baseUrl);

        var host = builder.Build();
        try
        {
            var app = host.Services.GetRequiredService<App>();
            await app.Run(cts.Token);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
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

    private static void ConfigureServices(IServiceCollection services, string baseUrl)
    {
        services.AddTransient<App>();

        services.AddFylumClient(options =>
        {
            options.BaseUri = new Uri(baseUrl);
            options.Timeout = TimeSpan.FromSeconds(60);
        });
    }
}
