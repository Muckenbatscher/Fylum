using Fylum.Client;
using Fylum.Web;
using Fylum.Web.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
