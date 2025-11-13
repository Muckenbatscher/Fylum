using M2TWinForms.Themes;
using M2TWinForms.Themes.MaterialDesign;
using M2TWinForms.Themes.ThemeProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Winforms
{
    internal class ThemeProvider : IDefaultThemeProvider
    {
        public Theme CreateTheme()
        {
            return Theme.CreateFromSinglePrimaryColor(
                Color.Green, ThemeMode.Dark, ContrastLevel.Normal, true);
        }
    }
}
