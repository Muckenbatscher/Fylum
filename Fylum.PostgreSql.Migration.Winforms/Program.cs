using Fylum.PostgreSql.Migration.Application;
using Fylum.PostgreSql.Migration.Domain;
using Fylum.PostgreSql.Migration.Domain.PerformedMigrations;
using Fylum.PostgreSql.Migration.Provider;
using Fylum.PostgreSql.Migrations.PostgreSql.PerformedMigrations;
using Fylum.PostgreSql.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fylum.PostgreSql.Migration.Winforms
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

            builder.Services.AddTransient<IPerformedMigrationsRepository, PerformedMigrationsRepository>();

            builder.Services.AddTransient<MigrationMainWindow>();

            using (var host = builder.Build())
            {
                var serviceProvider = host.Services;
                var mainForm = serviceProvider.GetRequiredService<MigrationMainWindow>();
                
                System.Windows.Forms.Application.Run(mainForm);
            }
        }
    }
}