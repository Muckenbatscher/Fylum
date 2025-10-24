using Fylum.Migration.Application;
using Fylum.Migration.PostgreSql;
using Fylum.Migration.Provider;
using Fylum.Migration.Winforms.MainWindow;
using Fylum.PostgreSql;
using Fylum.PostgreSql.Migration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fylum.Migration.Winforms
{
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

            builder.Services.AddPostgreSqlSharedServices(options =>
            {
                options.HostName = builder.Configuration["DbConnection:Host"]!;
                options.Port = int.Parse(builder.Configuration["DbConnection:Port"]!);
                options.DatabaseName = builder.Configuration["DbConnection:Database"]!;
                options.Username = builder.Configuration["DbConnection:Username"]!;
                options.Password = builder.Configuration["DbConnection:Password"]!;
            });
            builder.Services.AddPostgreSqlMigrationProviderServices();
            builder.Services.AddPostgreSqlMigrationApplicationServices();

            builder.Services.AddPostgreSqlMigrationPostgreSqlServices();

            builder.Services.AddTransient<IMigrationMainWindow, MigrationMainWindow>();
            builder.Services.AddTransient<MigrationMainWindowPresenter>();

            using (var host = builder.Build())
            {
                var serviceProvider = host.Services;
                var mainFormPresenter = serviceProvider.GetRequiredService<MigrationMainWindowPresenter>();
                
                var form = (Form)mainFormPresenter.View;
                System.Windows.Forms.Application.Run(form);
            }
        }
    }
}