using MaterialTheming;

namespace Fylum.Web.MaterialTheming.CssBuilding;

internal class MaterialThemeCssVariableExtractor : IMaterialThemeCssVariableExtractor
{
    public IEnumerable<string> ExtractCssVariables(ThemeColors themeColors)
    {
        // Primary
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.Primary, themeColors.Primary);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnPrimary, themeColors.OnPrimary);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.PrimaryContainer, themeColors.PrimaryContainer);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnPrimaryContainer, themeColors.OnPrimaryContainer);
        // Secondary
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.Secondary, themeColors.Secondary);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnSecondary, themeColors.OnSecondary);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SecondaryContainer, themeColors.SecondaryContainer);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnSecondaryContainer, themeColors.OnSecondaryContainer);
        // Tertiary
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.Tertiary, themeColors.Tertiary);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnTertiary, themeColors.OnTertiary);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.TertiaryContainer, themeColors.TertiaryContainer);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnTertiaryContainer, themeColors.OnTertiaryContainer);
        // Error
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.Error, themeColors.Error);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnError, themeColors.OnError);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.ErrorContainer, themeColors.ErrorContainer);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnErrorContainer, themeColors.OnErrorContainer);
        // Surface
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.Surface, themeColors.Surface);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SurfaceVariant, themeColors.SurfaceVariant);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnSurface, themeColors.OnSurface);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnSurfaceVariant, themeColors.OnSurfaceVariant);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SurfaceDim, themeColors.SurfaceDim);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SurfaceBright, themeColors.SurfaceBright);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SurfaceTint, themeColors.SurfaceTint);
        // Background
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.Background, themeColors.Background);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnBackground, themeColors.OnBackground);
        // Outline
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.Outline, themeColors.Outline);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OutlineVariant, themeColors.OutlineVariant);
        // Shadow
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.Shadow, themeColors.Shadow);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.Scrim, themeColors.Scrim);
        // Inverse
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.InverseSurface, themeColors.InverseSurface);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.InverseOnSurface, themeColors.InverseOnSurface);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.InversePrimary, themeColors.InversePrimary);
        // Primary Fixed
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.PrimaryFixed, themeColors.PrimaryFixed);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnPrimaryFixed, themeColors.OnPrimaryFixed);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.PrimaryFixedDim, themeColors.PrimaryFixedDim);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnPrimaryFixedVariant, themeColors.OnPrimaryFixedVariant);
        // Secondary Fixed
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SecondaryFixed, themeColors.SecondaryFixed);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnSecondaryFixed, themeColors.OnSecondaryFixed);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SecondaryFixedDim, themeColors.SecondaryFixedDim);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnSecondaryFixedVariant, themeColors.OnSecondaryFixedVariant);
        // Tertiary Fixed
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.TertiaryFixed, themeColors.TertiaryFixed);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnTertiaryFixed, themeColors.OnTertiaryFixed);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.TertiaryFixedDim, themeColors.TertiaryFixedDim);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.OnTertiaryFixedVariant, themeColors.OnTertiaryFixedVariant);
        // Surface Container
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SurfaceContainerLowest, themeColors.SurfaceContainerLowest);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SurfaceContainerLow, themeColors.SurfaceContainerLow);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SurfaceContainer, themeColors.SurfaceContainer);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SurfaceContainerHigh, themeColors.SurfaceContainerHigh);
        yield return GetCssVariableFromRgbColor(MaterialThemingVariables.SurfaceContainerHighest, themeColors.SurfaceContainerHighest);
    }

    private static string GetCssVariableFromRgbColor(string variableName, RgbColor rgbColor)
        => $"{variableName}: {rgbColor.CssRgbString};";

}
