namespace Fylum.Web.MaterialTheming.CssBuilding;

internal class MaterialThemeCssClassBuilder : IMaterialThemeCssClassBuilder
{
    public IEnumerable<string> CreateCssClasses()
    {
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.Primary,
            MaterialThemingVariables.Primary, MaterialThemingVariables.OnPrimary);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.PrimaryTransparent,
            MaterialThemingVariables.Primary);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.PrimaryContainer,
            MaterialThemingVariables.PrimaryContainer, MaterialThemingVariables.OnPrimaryContainer);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.Secondary,
            MaterialThemingVariables.Secondary, MaterialThemingVariables.OnSecondary);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.Secondary,
            MaterialThemingVariables.Secondary);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SecondaryContainer,
            MaterialThemingVariables.SecondaryContainer, MaterialThemingVariables.OnSecondaryContainer);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.Tertiary,
            MaterialThemingVariables.Tertiary, MaterialThemingVariables.OnTertiary);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.Tertiary,
            MaterialThemingVariables.Tertiary);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.TertiaryContainer,
            MaterialThemingVariables.TertiaryContainer, MaterialThemingVariables.OnTertiaryContainer);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.Error,
            MaterialThemingVariables.Error, MaterialThemingVariables.OnError);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.Error,
            MaterialThemingVariables.Error);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.ErrorContainer,
            MaterialThemingVariables.ErrorContainer, MaterialThemingVariables.OnErrorContainer);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.Surface,
            MaterialThemingVariables.Surface, MaterialThemingVariables.OnSurface);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SurfaceVariant,
            MaterialThemingVariables.SurfaceVariant, MaterialThemingVariables.OnSurfaceVariant);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OnSurface,
            MaterialThemingVariables.OnSurface);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OnSurfaceVariant,
            MaterialThemingVariables.OnSurfaceVariant);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SurfaceDim,
            MaterialThemingVariables.SurfaceDim, MaterialThemingVariables.OnSurface);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SurfaceBright,
            MaterialThemingVariables.SurfaceBright, MaterialThemingVariables.OnSurface);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SurfaceTint,
            MaterialThemingVariables.SurfaceTint, MaterialThemingVariables.OnSurface);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.Background,
            MaterialThemingVariables.Background, MaterialThemingVariables.OnBackground);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OnBackground,
            MaterialThemingVariables.OnBackground);

        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.Outline,
            MaterialThemingVariables.Outline);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OutlineVariant,
            MaterialThemingVariables.OutlineVariant);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.Shadow,
            MaterialThemingVariables.Shadow, MaterialThemingVariables.Shadow);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.Scrim,
            MaterialThemingVariables.Scrim, MaterialThemingVariables.Scrim);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.InverseSurface,
            MaterialThemingVariables.InverseSurface, MaterialThemingVariables.InverseOnSurface);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.InverseOnSurface,
            MaterialThemingVariables.InverseOnSurface);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.InversePrimary,
            MaterialThemingVariables.InversePrimary);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.PrimaryFixed,
            MaterialThemingVariables.PrimaryFixed, MaterialThemingVariables.OnPrimaryFixed);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OnPrimaryFixed,
            MaterialThemingVariables.OnPrimaryFixed);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.PrimaryFixedDim,
            MaterialThemingVariables.PrimaryFixedDim, MaterialThemingVariables.OnPrimaryFixed);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OnPrimaryFixedVariant,
            MaterialThemingVariables.OnPrimaryFixedVariant);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SecondaryFixed,
            MaterialThemingVariables.SecondaryFixed, MaterialThemingVariables.OnSecondaryFixed);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OnSecondaryFixed,
            MaterialThemingVariables.OnSecondaryFixed);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SecondaryFixedDim,
            MaterialThemingVariables.SecondaryFixedDim, MaterialThemingVariables.OnSecondaryFixed);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OnSecondaryFixedVariant,
            MaterialThemingVariables.OnSecondaryFixedVariant);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.TertiaryFixed,
            MaterialThemingVariables.TertiaryFixed, MaterialThemingVariables.OnTertiaryFixed);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OnTertiaryFixed,
            MaterialThemingVariables.OnTertiaryFixed);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.TertiaryFixedDim,
            MaterialThemingVariables.TertiaryFixedDim, MaterialThemingVariables.OnTertiaryFixed);
        yield return GetForegroundCssClassFromColorVariable(MaterialThemingClasses.OnTertiaryFixedVariant,
            MaterialThemingVariables.OnTertiaryFixedVariant);

        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SurfaceContainerLowest,
            MaterialThemingVariables.SurfaceContainerLowest, MaterialThemingVariables.OnSurface);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SurfaceContainerLow,
            MaterialThemingVariables.SurfaceContainerLow, MaterialThemingVariables.OnSurface);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SurfaceContainer,
            MaterialThemingVariables.SurfaceContainer, MaterialThemingVariables.OnSurface);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SurfaceContainerHigh,
            MaterialThemingVariables.SurfaceContainerHigh, MaterialThemingVariables.OnSurface);
        yield return GetFullCssClassFromColorVariables(MaterialThemingClasses.SurfaceContainerHighest,
            MaterialThemingVariables.SurfaceContainerHighest, MaterialThemingVariables.OnSurface);
    }

    private static string GetFullCssClassFromColorVariables(string className, string backgroundVariable, string foregroundVariable)
    {
        return $$"""
        .{{className}} {
            background - color: var({{backgroundVariable}}) !important;
            color: var({{foregroundVariable}}) !important;
         }
        """;
    }
    private static string GetForegroundCssClassFromColorVariable(string className, string foregroundVariable)
    {
        return $$"""
        .{{className}} {
            background-color: transparent;
            color: var({{foregroundVariable}}) !important;        }
        """;
    }
    private static string GetBackgroundCssClassFromColorVariable(string className, string backgroundVariable)
    {
        return $$"""
        .{{className}} {
            background-color: var({{backgroundVariable}}) !important;
        }
        """;
    }
}
