using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Web.MaterialTheming;

public static class MaterialThemeProviderServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddMaterialThemeProvider()
        {
            services.AddSingleton<IMaterialThemeProvider, MaterialThemeProvider>();
            return services;
        }
    }
}
