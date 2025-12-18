using M2TWinForms.Themes;
using M2TWinForms.Themes.MaterialDesign;
using MudBlazor;
using MudBlazor.Utilities;

namespace Fylum.Migrations.Web;

public class ThemeProvider : IThemeProvider
{
    public MudTheme GetTheme()
    {
        var color = System.Drawing.Color.Violet;

        var paletteDark = new PaletteDark();
        var m2tDarkTheme = Theme.CreateFromSinglePrimaryColor(color, ThemeMode.Dark, ContrastLevel.Normal, true);
        ApplyM2TThemeToPalette(m2tDarkTheme, paletteDark);

        var paletteLight = new PaletteLight();
        var m2tLightTheme = Theme.CreateFromSinglePrimaryColor(color, ThemeMode.Light, ContrastLevel.Normal, true);
        ApplyM2TThemeToPalette(m2tLightTheme, paletteLight);

        return new MudTheme()
        {
            PaletteDark = paletteDark,
            PaletteLight = paletteLight,
            LayoutProperties = new LayoutProperties()
        };
    }

    private void ApplyM2TThemeToPalette(Theme m2tTheme, Palette palette)
    {
        palette.Primary = GetFromSystemDrawingColor(m2tTheme.Colors.Primary);
        palette.PrimaryContrastText = GetFromSystemDrawingColor(m2tTheme.Colors.OnPrimary);
        palette.Secondary = GetFromSystemDrawingColor(m2tTheme.Colors.Secondary);
        palette.SecondaryContrastText = GetFromSystemDrawingColor(m2tTheme.Colors.OnSecondary);
        palette.Tertiary = GetFromSystemDrawingColor(m2tTheme.Colors.Tertiary);
        palette.TertiaryContrastText = GetFromSystemDrawingColor(m2tTheme.Colors.OnTertiary);
        palette.Error = GetFromSystemDrawingColor(m2tTheme.Colors.Error);
        palette.ErrorContrastText = GetFromSystemDrawingColor(m2tTheme.Colors.OnError);
        palette.Background = GetFromSystemDrawingColor(m2tTheme.Colors.Surface);
        palette.Surface = GetFromSystemDrawingColor(m2tTheme.Colors.Surface);
        palette.TextPrimary = GetFromSystemDrawingColor(m2tTheme.Colors.OnSurface);
        palette.TextSecondary = GetFromSystemDrawingColor(m2tTheme.Colors.OnSurfaceVariant);
        palette.TextDisabled = GetFromSystemDrawingColor(m2tTheme.Colors.OnSurfaceVariant);
        palette.DrawerBackground = GetFromSystemDrawingColor(m2tTheme.Colors.SurfaceContainer);
        palette.DrawerText = GetFromSystemDrawingColor(m2tTheme.Colors.OnSurface);
        palette.DrawerIcon = GetFromSystemDrawingColor(m2tTheme.Colors.OnSurface);
        palette.AppbarBackground = GetFromSystemDrawingColor(m2tTheme.Colors.SurfaceContainerHigh);
        palette.AppbarText = GetFromSystemDrawingColor(m2tTheme.Colors.OnSurface);
    }

    private MudColor GetFromSystemDrawingColor(System.Drawing.Color color)
    {
        return new MudColor(color.R, color.G, color.B, color.A);
    }
}
