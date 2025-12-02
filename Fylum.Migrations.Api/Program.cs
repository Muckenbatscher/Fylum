using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Fylum.Api.Shared;
using Fylum.Migrations.Api;
using Fylum.Migrations.Api.PerformingAuthentication;
using Fylum.Postgres;
using Fylum.Postgres.Shared;
using System.Reflection;

namespace Fylum.Migrations.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddServiceDefaults(); // from Aspire Service Defaults

            builder.Services
                .AddAuthenticationJwtBearer(o => o.SigningKey = builder.Configuration["JwtAuth:SigningKey"])
                .AddAuthorization()
                .AddFastEndpoints()
                .SwaggerDocument();


            builder.Services.Configure<PerformingKeyOptions>(options =>
            {
                options.MigrationPerformingKey = builder.Configuration["MIGRATION_PERFORMING_KEY"]!;
            });

            builder.Services.AddPostgresSharedServices(options =>
            {
                options.HostName = builder.Configuration["POSTGRES_HOST"]!;
                options.Port = int.Parse(builder.Configuration["POSTGRES_PORT"]!);
                options.DatabaseName = builder.Configuration["POSTGRES_DATABASE"]!;
                options.Username = builder.Configuration["POSTGRES_USERNAME"]!;
                options.Password = builder.Configuration["POSTGRES_PASSWORD"]!;
            });
            builder.Services.AddPostgresServices();


            builder.Services.AddMigrationsServices();

            var app = builder.Build();

            app.UseAuthentication()
               .UseAuthorization();

            app.UseFastEndpoints();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerGen();
            }

            app.UseHttpsRedirection();
            app.UsePathBase("/api");

            app.Run();
        }
    }
}
