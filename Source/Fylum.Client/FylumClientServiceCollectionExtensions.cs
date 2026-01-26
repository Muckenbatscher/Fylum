using Fylum.Client.Auth;
using Fylum.Client.Auth.Token;
using Fylum.Client.Auth.Token.Expiration;
using Fylum.Client.Auth.Token.Storage;
using Fylum.Client.Folders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Fylum.Client;

public static class FylumClientServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFylumClients(Action<ClientOptions> configureClientOptions)
        {
            var defaultTokenStorageFactory = (IServiceProvider serviceProvider) => new InMemoryTokenStorage();
            return services.AddFylumClients(configureClientOptions, defaultTokenStorageFactory);
        }

        public IServiceCollection AddFylumClients(Action<ClientOptions> configureClientOptions,
            Func<IServiceProvider, ITokenStorage> tokenStorageFactory)
        {
            services.Configure(configureClientOptions);

            services.AddScoped<ITokenStorage>(tokenStorageFactory);

            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient<ITokenExpirationValidator, TokenExpirationValidator>();

            services.AddScoped<AccessTokenAuthHeaderHandler>();
            services.AddScoped<RefreshTokenAuthHeaderHandler>();

            services.AddConfiguredHttpClient<IAuthClient, AuthClient>();

            services.AddScopedTokenMessageHandlerClient<IRefreshTokenClient, RefreshTokenAuthHeaderHandler>(
                (serviceProvider, httpClient) => new RefreshTokenClient(httpClient));

            services.AddScopedAccessTokenMessageHandlerClient<IFolderClient>(
                (serviceProvider, httpClient) => new FolderClient(httpClient));

            return services;
        }

        private IServiceCollection AddScopedAccessTokenMessageHandlerClient<TClient>(Func<IServiceProvider, HttpClient, TClient> clientFactory)
             where TClient : class
        {
            return services.AddScopedTokenMessageHandlerClient<TClient, AccessTokenAuthHeaderHandler>(clientFactory);
        }

        private IServiceCollection AddScopedTokenMessageHandlerClient<TClient, THandler>(Func<IServiceProvider, HttpClient, TClient> clientFactory)
            where THandler : DelegatingHandler
            where TClient : class
        {
            string clientName = typeof(TClient).Name;
            services.AddHttpClient(clientName);

            return services.AddScoped<TClient>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<ClientOptions>>().Value;
                var authHandler = sp.GetRequiredService<THandler>();

                var handlerFactory = sp.GetRequiredService<IHttpMessageHandlerFactory>();
                var innerHandler = handlerFactory.CreateHandler(clientName);

                authHandler.InnerHandler = innerHandler;

                var httpClient = new HttpClient(authHandler)
                {
                    BaseAddress = options.BaseUri,
                    Timeout = options.Timeout
                };

                return clientFactory(sp, httpClient);
            });
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
