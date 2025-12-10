using Fylum.Client.Auth;
using Fylum.Client.Auth.Token;
using Fylum.Client.Auth.Token.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Fylum.Client;

public static class FylumClientServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFylumClient(Action<ClientOptions> configureClientOptions)
        {
            var defaultTokenStorageFactory = (IServiceProvider serviceProvider) => new InMemoryTokenStorage();
            return services.AddFylumClient(configureClientOptions, defaultTokenStorageFactory);
        }

        public IServiceCollection AddFylumClient(Action<ClientOptions> configureClientOptions,
            Func<IServiceProvider, ITokenStorage> tokenStorageFactory)
        {
            services.Configure(configureClientOptions);

            services.AddSingleton<ITokenStorage>(tokenStorageFactory);

            services.AddSingleton<ITokenService, TokenService>();
            services.AddTransient<AccessTokenAuthHeaderHandler>();
            services.AddHttpClient<IAuthClient, AuthClient>((serviceProvider, client) =>
            {
                var clientOptions = serviceProvider.GetRequiredService<IOptions<ClientOptions>>().Value;
                client.BaseAddress = clientOptions.BaseUri;
                client.Timeout = clientOptions.Timeout;
            });
            services.AddHttpClient<IRefreshTokenClient, RefreshTokenClient>((serviceProvider, client) =>
            {
                var clientOptions = serviceProvider.GetRequiredService<IOptions<ClientOptions>>().Value;
                client.BaseAddress = clientOptions.BaseUri;
                client.Timeout = clientOptions.Timeout;
            });

            services.AddAccessTokenConfiguredTypedHttpClient<IFylumClient, FylumClient>();

            return services;
        }

        private IServiceCollection AddAccessTokenConfiguredTypedHttpClient<TClient, TImplementation>()
            where TImplementation : class, TClient
            where TClient : class
        {
            services.AddHttpClient<TClient, TImplementation>(configureClient: (serviceProvider, client) =>
            {
                var clientOptions = serviceProvider.GetRequiredService<IOptions<ClientOptions>>().Value;
                client.BaseAddress = clientOptions.BaseUri;
                client.Timeout = clientOptions.Timeout;
            }).AddHttpMessageHandler<AccessTokenAuthHeaderHandler>();

            return services;
        }
    }
}
