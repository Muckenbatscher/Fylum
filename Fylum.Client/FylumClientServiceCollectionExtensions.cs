using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Client;

public static class FylumClientServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFylumClient()
        {
            return services;
        }
    }
}
