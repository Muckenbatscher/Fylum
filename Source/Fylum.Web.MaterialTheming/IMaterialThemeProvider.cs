using MaterialTheming;

namespace Fylum.Web.MaterialTheming;

public interface IMaterialThemeProvider
{
    ThemeColors GetThemeColors(ThemeMode themeMode);
}