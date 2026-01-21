using MaterialTheming;
using MudBlazor;
using MudBlazor.Utilities;

namespace Fylum.Web;

public class ThemeProvider : IThemeProvider
{
    public MudTheme GetTheme()
    {
        var sourceColor = "#EE82EE";

        var themeBuilder = ThemeBuilder
            .CreateFromSourceColor(sourceColor)
            .WithContrastLevel(ContrastLevel.Normal);

        var paletteDark = new PaletteDark();
        var darkTheme = themeBuilder.WithMode(ThemeMode.Dark).Build();
        ApplyMaterialThemeColorsToPalette(darkTheme, paletteDark);

        var paletteLight = new PaletteLight();
        var lightTheme = themeBuilder.WithMode(ThemeMode.Light).Build();
        ApplyMaterialThemeColorsToPalette(lightTheme, paletteLight);

        return new MudTheme()
        {
            PaletteDark = paletteDark,
            PaletteLight = paletteLight,
            LayoutProperties = new LayoutProperties()
        };
    }

    private void ApplyMaterialThemeColorsToPalette(ThemeColors materialThemeColors, Palette palette)
    {
        palette.Primary = GetFromRgbColor(materialThemeColors.Primary);
        palette.PrimaryContrastText = GetFromRgbColor(materialThemeColors.OnPrimary);
        palette.Secondary = GetFromRgbColor(materialThemeColors.Secondary);
        palette.SecondaryContrastText = GetFromRgbColor(materialThemeColors.OnSecondary);
        palette.Tertiary = GetFromRgbColor(materialThemeColors.Tertiary);
        palette.TertiaryContrastText = GetFromRgbColor(materialThemeColors.OnTertiary);
        palette.Error = GetFromRgbColor(materialThemeColors.Error);
        palette.ErrorContrastText = GetFromRgbColor(materialThemeColors.OnError);
        palette.Background = GetFromRgbColor(materialThemeColors.Surface);
        palette.Surface = GetFromRgbColor(materialThemeColors.Surface);
        palette.TextPrimary = GetFromRgbColor(materialThemeColors.OnSurface);
        palette.TextSecondary = GetFromRgbColor(materialThemeColors.OnSurfaceVariant);
        palette.TextDisabled = GetFromRgbColor(materialThemeColors.OnSurfaceVariant);
        palette.DrawerBackground = GetFromRgbColor(materialThemeColors.SurfaceContainer);
        palette.DrawerText = GetFromRgbColor(materialThemeColors.OnSurface);
        palette.DrawerIcon = GetFromRgbColor(materialThemeColors.OnSurface);
        palette.AppbarBackground = GetFromRgbColor(materialThemeColors.SurfaceContainerHigh);
        palette.AppbarText = GetFromRgbColor(materialThemeColors.OnSurface);
    }

    private MudColor GetFromRgbColor(RgbColor color)
    {
        return new MudColor(color.Red, color.Green, color.Blue, byte.MaxValue);
    }
}
