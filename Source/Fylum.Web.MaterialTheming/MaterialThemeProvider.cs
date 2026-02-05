using MaterialTheming;

namespace Fylum.Web.MaterialTheming;

public class MaterialThemeProvider : IMaterialThemeProvider
{
    private readonly IColorPaletteThemeBuilder _configuredThemeBuilder;

    public MaterialThemeProvider()
    {
        var sourceColor = HctColor.From(90, 50, 50);
        _configuredThemeBuilder = ThemeBuilder
            .CreateFromSourceColor(sourceColor)
            .WithContrastLevel(ContrastLevel.Normal);
    }

    public ThemeColors GetThemeColors(ThemeMode themeMode)
    {
        return _configuredThemeBuilder
            .WithMode(themeMode)
            .Build();
    }
}
