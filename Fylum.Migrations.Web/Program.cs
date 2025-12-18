using Fylum.Migrations.Client;
using Fylum.Migrations.Web;
using Fylum.Migrations.Web.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IThemeProvider, ThemeProvider>();
builder.Services.AddMigrationClient(options =>
{
    var baseAddress = builder.Configuration["MigrationsClientOptions:BaseAddress"]!;
    options.BaseUri = new Uri(baseAddress!);

    int timeOutSeconds = int.TryParse(builder.Configuration["MigrationsClientOptions:TimeOutSeconds"], out timeOutSeconds)
        ? timeOutSeconds : 30;
    options.Timeout = TimeSpan.FromSeconds(timeOutSeconds);
    options.MigrationPerformingKey = builder.Configuration["MIGRATION_PERFORMING_KEY"]!;
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
