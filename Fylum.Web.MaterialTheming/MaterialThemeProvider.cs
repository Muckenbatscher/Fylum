using MaterialTheming;
using MaterialTheming.Creation;
using MaterialTheming.MaterialDesign;

namespace Fylum.Web.MaterialTheming;

public class MaterialThemeProvider : IMaterialThemeProvider
{
    private readonly IThemeBuilder _configuredThemeBuilder;

    public MaterialThemeProvider()
    {
        _configuredThemeBuilder = ThemeBuilder.Create()
            .WithPrimaryColor(c => c.WithBaseColorHue(90))
            .WithContrastLevel(ContrastLevel.Normal);
    }

    public Theme GetTheme(ThemeMode themeMode)
    {
        return _configuredThemeBuilder
            .WithMode(themeMode)
            .Build();
    }
}
