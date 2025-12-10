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
            services.AddTransient<RefreshTokenAuthHeaderHandler>();
            services.AddConfiguredHttpClient<IAuthClient, AuthClient>();
            services.AddConfiguredHttpClient<IRefreshTokenClient, RefreshTokenClient>()
                .AddHttpMessageHandler<RefreshTokenAuthHeaderHandler>();

            services.AddConfiguredAccessTokenHttpClient<IFylumClient, FylumClient>();

            return services;
        }

        private IHttpClientBuilder AddConfiguredAccessTokenHttpClient<TClient, TImplementation>()
            where TImplementation : class, TClient
            where TClient : class
        {
            return services
                .AddConfiguredHttpClient<TClient, TImplementation>()
                .AddHttpMessageHandler<AccessTokenAuthHeaderHandler>();
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
