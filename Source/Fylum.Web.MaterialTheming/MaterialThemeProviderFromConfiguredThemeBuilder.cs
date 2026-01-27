using MaterialTheming;
using MaterialTheming.Creation;

namespace Fylum.Web.MaterialTheming;

public class MaterialThemeProviderFromConfiguredThemeBuilder : IMaterialThemeProvider
{
    private readonly IColorPaletteThemeBuilder _themeBuilder;

    public MaterialThemeProviderFromConfiguredThemeBuilder(IColorPaletteThemeBuilder themeBuilder)
    {
        _themeBuilder = themeBuilder;
    }

    public ThemeColors GetThemeColors(ThemeMode themeMode)
    {
        return _themeBuilder.WithMode(themeMode).Build();
    }
}
