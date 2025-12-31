using Fylum.Client;
using Fylum.Web.Components;
using MudBlazor.Services;

namespace Fylum.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        builder.Services.AddMudServices();

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddSingleton<IThemeProvider, ThemeProvider>();
        builder.Services.AddFylumClients(options =>
        {
            var baseAddress = builder.Configuration["FylumClientOptions:BaseAddress"]!;
            options.BaseUri = new Uri(baseAddress!);

            int timeOutSeconds = int.TryParse(builder.Configuration["FylumClientOptions:TimeOutSeconds"], out timeOutSeconds)
                ? timeOutSeconds : 30;
            options.Timeout = TimeSpan.FromSeconds(timeOutSeconds);
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
