using Fylum.PostgreSql.Migration.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fylum.PostgreSql.Migration
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

            builder.Services.AddTransient<IMigrationsProvider, DiscoveringMigrationsProvider>();
            builder.Services.AddTransient<Form1>();
            builder.Services.AddPostgreSqlServices(options =>
            {
                options.HostName = builder.Configuration["DbConnection:Host"]!;
                options.Port = int.Parse(builder.Configuration["DbConnection:Port"]!);
                options.DatabaseName = builder.Configuration["DbConnection:Database"]!;
                options.Username = builder.Configuration["DbConnection:Username"]!;
                options.Password = builder.Configuration["DbConnection:Password"]!;
            });

            using (var host = builder.Build())
            {
                var serviceProvider = host.Services;
                var mainForm = serviceProvider.GetRequiredService<Form1>();
                
                Application.Run(mainForm);
            }
        }
    }
}