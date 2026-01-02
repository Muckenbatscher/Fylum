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
        ApplyMaterialThemeToPalette(darkTheme, paletteDark);

        var paletteLight = new PaletteLight();
        var lightTheme = themeBuilder.WithMode(ThemeMode.Light).Build();
        ApplyMaterialThemeToPalette(lightTheme, paletteLight);

        return new MudTheme()
        {
            PaletteDark = paletteDark,
            PaletteLight = paletteLight,
            LayoutProperties = new LayoutProperties()
        };
    }

    private void ApplyMaterialThemeToPalette(Theme materialTheme, Palette palette)
    {
        palette.Primary = GetFromRgbColor(materialTheme.Colors.Primary);
        palette.PrimaryContrastText = GetFromRgbColor(materialTheme.Colors.OnPrimary);
        palette.Secondary = GetFromRgbColor(materialTheme.Colors.Secondary);
        palette.SecondaryContrastText = GetFromRgbColor(materialTheme.Colors.OnSecondary);
        palette.Tertiary = GetFromRgbColor(materialTheme.Colors.Tertiary);
        palette.TertiaryContrastText = GetFromRgbColor(materialTheme.Colors.OnTertiary);
        palette.Error = GetFromRgbColor(materialTheme.Colors.Error);
        palette.ErrorContrastText = GetFromRgbColor(materialTheme.Colors.OnError);
        palette.Background = GetFromRgbColor(materialTheme.Colors.Surface);
        palette.Surface = GetFromRgbColor(materialTheme.Colors.Surface);
        palette.TextPrimary = GetFromRgbColor(materialTheme.Colors.OnSurface);
        palette.TextSecondary = GetFromRgbColor(materialTheme.Colors.OnSurfaceVariant);
        palette.TextDisabled = GetFromRgbColor(materialTheme.Colors.OnSurfaceVariant);
        palette.DrawerBackground = GetFromRgbColor(materialTheme.Colors.SurfaceContainer);
        palette.DrawerText = GetFromRgbColor(materialTheme.Colors.OnSurface);
        palette.DrawerIcon = GetFromRgbColor(materialTheme.Colors.OnSurface);
        palette.AppbarBackground = GetFromRgbColor(materialTheme.Colors.SurfaceContainerHigh);
        palette.AppbarText = GetFromRgbColor(materialTheme.Colors.OnSurface);
    }

    private MudColor GetFromRgbColor(RgbColor color)
    {
        return new MudColor(color.Red, color.Green, color.Blue, byte.MaxValue);
    }
}
