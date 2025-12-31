using MaterialTheming;
using MaterialTheming.ColorDefinitions;
using MaterialTheming.Creation;
using MaterialTheming.MaterialDesign;
using MudBlazor;
using MudBlazor.Utilities;

namespace Fylum.Web;

public class ThemeProvider : IThemeProvider
{
    public MudTheme GetTheme()
    {
        var color = "#EE82EE";

        var themeBuilder = ThemeBuilder.Create()
            .WithPrimaryColor(c => c.WithBaseColor(color))
            .WithContrastLevel(ContrastLevel.Normal);

        var paletteDark = new PaletteDark();
        var darkTheme = themeBuilder.WithMode(ThemeMode.Dark).Build();
        ApplyM2TThemeToPalette(darkTheme, paletteDark);

        var paletteLight = new PaletteLight();
        var lightTheme = themeBuilder.WithMode(ThemeMode.Light).Build();
        ApplyM2TThemeToPalette(lightTheme, paletteLight);

        return new MudTheme()
        {
            PaletteDark = paletteDark,
            PaletteLight = paletteLight,
            LayoutProperties = new LayoutProperties()
        };
    }

    private void ApplyM2TThemeToPalette(Theme m2tTheme, Palette palette)
    {
        palette.Primary = GetFromRgbColor(m2tTheme.Colors.Primary);
        palette.PrimaryContrastText = GetFromRgbColor(m2tTheme.Colors.OnPrimary);
        palette.Secondary = GetFromRgbColor(m2tTheme.Colors.Secondary);
        palette.SecondaryContrastText = GetFromRgbColor(m2tTheme.Colors.OnSecondary);
        palette.Tertiary = GetFromRgbColor(m2tTheme.Colors.Tertiary);
        palette.TertiaryContrastText = GetFromRgbColor(m2tTheme.Colors.OnTertiary);
        palette.Error = GetFromRgbColor(m2tTheme.Colors.Error);
        palette.ErrorContrastText = GetFromRgbColor(m2tTheme.Colors.OnError);
        palette.Background = GetFromRgbColor(m2tTheme.Colors.Surface);
        palette.Surface = GetFromRgbColor(m2tTheme.Colors.Surface);
        palette.TextPrimary = GetFromRgbColor(m2tTheme.Colors.OnSurface);
        palette.TextSecondary = GetFromRgbColor(m2tTheme.Colors.OnSurfaceVariant);
        palette.TextDisabled = GetFromRgbColor(m2tTheme.Colors.OnSurfaceVariant);
        palette.DrawerBackground = GetFromRgbColor(m2tTheme.Colors.SurfaceContainer);
        palette.DrawerText = GetFromRgbColor(m2tTheme.Colors.OnSurface);
        palette.DrawerIcon = GetFromRgbColor(m2tTheme.Colors.OnSurface);
        palette.AppbarBackground = GetFromRgbColor(m2tTheme.Colors.SurfaceContainerHigh);
        palette.AppbarText = GetFromRgbColor(m2tTheme.Colors.OnSurface);
    }

    private MudColor GetFromRgbColor(RgbColor color)
    {
        return new MudColor(color.Red, color.Green, color.Blue, byte.MaxValue);
    }
}
