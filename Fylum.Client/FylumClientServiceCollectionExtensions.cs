using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Fylum.Client;

public static class FylumClientServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFylumClient(Action<ClientOptions> configureClientOptions)
        {
            services.Configure(configureClientOptions);

            services.AddHttpClient<IFylumClient, FylumClient>((serviceProvider, client) =>
            {
                var clientOptions = serviceProvider.GetRequiredService<IOptions<ClientOptions>>().Value;
                client.BaseAddress = clientOptions.BaseUri;
                client.Timeout = clientOptions.Timeout;
            });

            return services;
        }
    }
}
