using Fylum.Api.EndToEndTest.Common.DistributedApplicationBuilding;
using Fylum.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Api.EndToEndTest.Common.ClientApplicationBuilding;

public class ClientApplicationFactory
{
    public static async Task<ClientApplication> CreateAsync(CancellationToken cancellationToken)
    {
        var distributedApp = await DistributedApplicationContainerFactory.CreateAsync(cancellationToken,
            migrate: true, persistent: false);

        var apiBaseUri = distributedApp.GetApiBaseUri();
        if (apiBaseUri == null)
            throw new Exception("Api is not initialized");

        var clientServices = new ServiceCollection();
        clientServices.AddFylumClients(options =>
        {
            options.BaseUri = apiBaseUri;
            options.Timeout = TimeSpan.FromSeconds(5);
        });
        var clientServiceProvider = clientServices.BuildServiceProvider();

        return new ClientApplication(distributedApp, clientServiceProvider);
    }
}
