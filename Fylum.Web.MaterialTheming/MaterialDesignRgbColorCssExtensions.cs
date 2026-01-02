using MaterialTheming.ColorDefinitions;

namespace Fylum.Web.MaterialTheming;

internal static class MaterialDesignRgbColorCssExtensions
{
    extension(RgbColor color)
    {
        public string CssRgbString => $"rgb({color.Red}, {color.Green}, {color.Blue})";
    }
}
