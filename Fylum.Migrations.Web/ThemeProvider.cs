using Fylum.Web.MaterialTheming;
using MaterialTheming;
using MudBlazor;
using MudBlazor.Utilities;

namespace Fylum.Migrations.Web;

public class ThemeProvider : IThemeProvider
{
    private readonly IMaterialThemeProvider _themeProvider;

    public ThemeProvider(IMaterialThemeProvider themeProvider)
    {
        _themeProvider = themeProvider;
    }

    public MudTheme GetTheme()
    {
        var paletteDark = new PaletteDark();
        var darkTheme = _themeProvider.GetThemeColors(ThemeMode.Dark);
        ApplyMaterialThemeToPalette(darkTheme, paletteDark);

        var paletteLight = new PaletteLight();
        var lightTheme = _themeProvider.GetThemeColors(ThemeMode.Light);
        ApplyMaterialThemeToPalette(lightTheme, paletteLight);

        return new MudTheme()
        {
            PaletteDark = paletteDark,
            PaletteLight = paletteLight,
            LayoutProperties = new LayoutProperties()
        };
    }

    private void ApplyMaterialThemeToPalette(ThemeColors materialThemeColors, Palette palette)
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
