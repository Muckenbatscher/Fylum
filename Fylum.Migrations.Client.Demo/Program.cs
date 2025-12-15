using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Client.Listing;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Fylum.Migrations.Client.Demo;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("BaseUrl: ");
        var baseUrl = Console.ReadLine()!;
        Console.Write("PerformingKey: ");
        var performingKey = Console.ReadLine()!;

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, baseUrl, performingKey);
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
    private static void ConfigureServices(IServiceCollection services, string baseUrl, string performingKey)
    {
        services.AddTransient<App>();
        services.AddTransient<IMigrationsClient>((sp) =>
        {
            var mock = new Mock<IMigrationsClient>();
            mock.Setup(x => x.GetMigrationsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetDummyMultipleMigrationsResponse());
            return mock.Object;
        });

        //services.AddMigrationClient(options =>
        //{
        //    options.BaseUri = new Uri(baseUrl);
        //    options.MigrationPerformingKey = performingKey;
        //    options.Timeout = TimeSpan.FromSeconds(60);
        //});
    }

    private static MultipleMigrationsResponse GetDummyMultipleMigrationsResponse()
    {
        var migrationOne = new MigrationResponse(Guid.NewGuid(), "migration One", true);
        var migrationTwo = new MigrationResponse(Guid.NewGuid(), "migration Two", true);
        var migrationThree = new MigrationResponse(Guid.NewGuid(), "migration Three", false);
        return new MultipleMigrationsResponse([migrationOne, migrationTwo, migrationThree]);
    }
}
