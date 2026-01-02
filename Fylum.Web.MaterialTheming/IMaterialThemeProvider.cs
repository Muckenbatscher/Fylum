using MaterialTheming;
using MaterialTheming.MaterialDesign;

namespace Fylum.Web.MaterialTheming;

public interface IMaterialThemeProvider
{
    Theme GetTheme(ThemeMode themeMode);
}