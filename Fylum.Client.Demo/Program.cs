using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Client.Demo;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("BaseUrl: ");
        var baseUrl = Console.ReadLine()!;

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, baseUrl);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        try
        {
            var app = serviceProvider.GetRequiredService<App>();
            await app.Run(CancellationToken.None);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
        }
        finally
        {
            if (serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
        Console.ReadLine();
    }

    /// <summary>
    /// Hier werden alle Abhängigkeiten definiert.
    /// </summary>
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
