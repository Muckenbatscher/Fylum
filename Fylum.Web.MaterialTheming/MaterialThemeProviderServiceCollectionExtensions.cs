using MaterialTheming;
using MaterialTheming.Creation;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Web.MaterialTheming;

public static class MaterialThemeProviderServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddMaterialThemeProvider()
        {
            return services.AddMaterialThemeProvider(new MaterialThemeProvider());
        }
        public IServiceCollection AddMaterialThemeProvider(IMaterialThemeProvider materialThemeProvider)
        {
            return services.AddMaterialThemeProvider(sp => materialThemeProvider);
        }
        public IServiceCollection AddMaterialThemeProvider(Func<IServiceProvider, IMaterialThemeProvider> materialThemeProviderFactory)
        {
            return services.AddSingleton(materialThemeProviderFactory);
        }

        public IServiceCollection AddMaterialThemeProviderFromThemeBuilder(IColorPaletteThemeBuilder themeBuilder)
        {
            return services.AddMaterialThemeProviderFromThemeBuilder(sp => themeBuilder);
        }
        public IServiceCollection AddMaterialThemeProviderFromThemeBuilder(Func<IServiceProvider, IColorPaletteThemeBuilder> themeBuilderFactory)
        {
            return services.AddMaterialThemeProvider(sp =>
            {
                var themeBuilder = themeBuilderFactory(sp);
                var themeProvider = new MaterialThemeProviderFromConfiguredThemeBuilder(themeBuilder);
                return themeProvider;
            });
        }

    }
}
