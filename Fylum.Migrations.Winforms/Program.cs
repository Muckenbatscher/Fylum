using Fylum.Migrations.Client;
using Fylum.Migrations.Winforms.MainWindow;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fylum.Migrations.Winforms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddUserSecrets(typeof(Program).Assembly);

        builder.Services.AddMigrationClient(options =>
        {
            var baseUri = builder.Configuration["MigrationsApiBaseUrl"]!;
            options.BaseUri = new Uri(baseUri);
            options.MigrationPerformingKey = builder.Configuration["MigrationPerformingKey"]!;
            var timeoutSeconds = builder.Configuration["ApiTimeoutSeconds"];
            options.Timeout = TimeSpan.FromSeconds(int.Parse(timeoutSeconds!));
        });

        builder.Services.AddTransient<IMigrationMainWindow, MigrationMainWindow>();
        builder.Services.AddTransient<MigrationMainWindowPresenter>();

        using var host = builder.Build();
        var serviceProvider = host.Services;
        var mainFormPresenter = serviceProvider.GetRequiredService<MigrationMainWindowPresenter>();

        var form = (Form)mainFormPresenter.View;
        Application.Run(form);
    }
}