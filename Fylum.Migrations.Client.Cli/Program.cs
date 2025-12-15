using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fylum.Migrations.Client.Cli;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddServiceDiscovery();

        var performingKey = builder.Configuration["MIGRATION_PERFORMING_KEY"];
        if (string.IsNullOrEmpty(performingKey))
        {
            Console.Write("PerformingKey: ");
            performingKey = Console.ReadLine()!;
        }

        ConfigureServices(builder.Services, performingKey);
        var host = builder.Build();

        try
        {
            var app = host.Services.GetRequiredService<App>();
            await app.Run(CancellationToken.None);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
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

    private static void ConfigureServices(IServiceCollection services, string performingKey)
    {
        services.AddTransient<App>();

        services.AddMigrationClient(options =>
        {
            options.BaseUri = new Uri("https+http://migrations-api");
            options.MigrationPerformingKey = performingKey;
            options.Timeout = TimeSpan.FromSeconds(60);
        });
    }
}
