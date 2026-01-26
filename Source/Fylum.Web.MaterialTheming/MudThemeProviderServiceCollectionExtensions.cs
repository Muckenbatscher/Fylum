using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Web.MaterialTheming;

public static class MudThemeProviderServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddMudBlazorThemeProvider()
        {
            return services.AddSingleton<IMudThemeProvider, MudThemeProvider>();
        }
    }
}
