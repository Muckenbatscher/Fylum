using MaterialTheming;
using MaterialTheming.Creation;
using MaterialTheming.MaterialDesign;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fylum.Web.MaterialTheming;

public class MaterialThemeProviderFromConfiguredThemeBuilder : IMaterialThemeProvider
{
    private readonly IThemeBuilder _themeBuilder;

    public MaterialThemeProviderFromConfiguredThemeBuilder(IThemeBuilder themeBuilder)
    {
        _themeBuilder = themeBuilder;
    }

    public Theme GetTheme(ThemeMode themeMode)
    {
        return _themeBuilder.WithMode(themeMode).Build();
    }
}
