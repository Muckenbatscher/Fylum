using Fylum.Client;
using Fylum.Web;
using Fylum.Web.Components;
using Fylum.Web.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ProtectedLocalStorage>();

builder.Services.AddSingleton<IThemeProvider, ThemeProvider>();
builder.Services.AddScoped<ITokenCacheService, TokenCacheService>();
builder.Services.AddScoped<IBrowserTokenStorage, BrowserTokenStorage>();
builder.Services.AddFylumClients(configureClientOptions: options =>
{
    var baseAddress = builder.Configuration["FylumClientOptions:BaseAddress"]!;
    options.BaseUri = new Uri(baseAddress!);

    int timeOutSeconds = int.TryParse(builder.Configuration["FylumClientOptions:TimeOutSeconds"], out timeOutSeconds)
        ? timeOutSeconds : 30;
    options.Timeout = TimeSpan.FromSeconds(timeOutSeconds);
},
tokenStorageFactory: serviceProvider => serviceProvider.GetRequiredService<IBrowserTokenStorage>()
);

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
