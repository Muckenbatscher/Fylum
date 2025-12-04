using M2TWinForms.Themes;
using M2TWinForms.Themes.MaterialDesign;
using M2TWinForms.Themes.ThemeProviders;

namespace Fylum.Migrations.Winforms;

internal class ThemeProvider : IDefaultThemeProvider
{
    public Theme CreateTheme()
    {
        return Theme.CreateFromSinglePrimaryColor(
            Color.Green, ThemeMode.Dark, ContrastLevel.Normal, true);
    }
}