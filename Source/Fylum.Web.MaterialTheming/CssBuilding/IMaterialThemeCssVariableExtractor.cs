using MaterialTheming;

namespace Fylum.Web.MaterialTheming.CssBuilding;

internal interface IMaterialThemeCssVariableExtractor
{
    IEnumerable<string> ExtractCssVariables(ThemeColors themeColors);
}