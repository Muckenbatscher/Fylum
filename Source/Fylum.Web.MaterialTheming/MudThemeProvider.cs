using MaterialTheming;
using MudBlazor;

namespace Fylum.Web.MaterialTheming;

public class MudThemeProvider : IMudThemeProvider
{
    private readonly IMaterialThemeProvider _materialThemeProvider;

    public MudThemeProvider(IMaterialThemeProvider materialThemeProvider)
    {
        _materialThemeProvider = materialThemeProvider;
    }

    public MudTheme GetTheme()
    {
        return _materialThemeProvider.GetThemeBuilder()
            .BuildMudTheme();
    }
}
