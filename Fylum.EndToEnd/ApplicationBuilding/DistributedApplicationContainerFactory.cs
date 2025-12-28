using Aspire.Hosting.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fylum.EndToEnd.ApplicationBuilding;

internal class DistributedApplicationContainerFactory
{
    public static async Task<DistributedApplicationContainer> CreateAsync(CancellationToken cancellationToken,
        bool migrate = true, bool persistent = false)
    {
        var args = new List<string>();
        if (!persistent)
            args.Add("NonPersistent=true");

        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.Fylum_AppHost>(args.ToArray(), cancellationToken);

        appHost.Services.AddLogging(options => options.SetMinimumLevel(LogLevel.Debug));

        var app = await appHost.BuildAsync(cancellationToken);
        await app.StartAsync(cancellationToken);

        if (migrate)
        {
            var migrateResult = await app.ResourceCommands.ExecuteCommandAsync("migrations-api", "perform-all", cancellationToken);
            if (migrateResult == null || !migrateResult.Success)
                throw new Exception("Could not perform the migrations to the temporary database");
        }

        return new DistributedApplicationContainer(app);
    }
}
