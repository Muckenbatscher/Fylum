using Fylum.Migrations.Client.Auth;
using Fylum.Migrations.Client.Listing;
using Fylum.Migrations.Client.Performing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Fylum.Migrations.Client;

public static class FylumMigrationsClientServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddMigrationClient(Action<ClientOptions> configureClientOptions)
        {
            services.Configure(configureClientOptions);

            services.AddTransient<PerformingKeyAuthHeaderHandler>();

            services.AddConfiguredPerformingKeyHttpClient<IPerformingClient, PerformingClient>();
            services.AddConfiguredHttpClient<IMigrationsClient, MigrationsClient>();

            return services;
        }

        private IHttpClientBuilder AddConfiguredPerformingKeyHttpClient<TClient, TImplementation>()
            where TImplementation : class, TClient
            where TClient : class
        {
            return services
                .AddConfiguredHttpClient<TClient, TImplementation>()
                .AddHttpMessageHandler<PerformingKeyAuthHeaderHandler>();
        }
        private IHttpClientBuilder AddConfiguredHttpClient<TClient, TImplementation>()
            where TClient : class
            where TImplementation : class, TClient
        {
            return services.AddHttpClient<TClient, TImplementation>((serviceProvider, client) =>
            {
                var clientOptions = serviceProvider.GetRequiredService<IOptions<ClientOptions>>().Value;
                client.BaseAddress = clientOptions.BaseUri;
                client.Timeout = clientOptions.Timeout;
            });
        }
    }
}
