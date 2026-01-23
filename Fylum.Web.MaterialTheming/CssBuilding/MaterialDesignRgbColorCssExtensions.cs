using MaterialTheming;

namespace Fylum.Web.MaterialTheming.CssBuilding;

internal static class MaterialDesignRgbColorCssExtensions
{
    extension(RgbColor color)
    {
        public string CssRgbString => $"rgb({color.Red}, {color.Green}, {color.Blue})";
    }
}
