using FastEndpoints;
using FastEndpoints.Swagger;
using Fylum.Migrations.Api.PerformingAuthentication;
using Fylum.Postgres.Shared;
using Microsoft.AspNetCore.Authentication;
using Scalar.AspNetCore;

namespace Fylum.Migrations.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults(); // from Aspire Service Defaults

        builder.Services
            .AddFastEndpoints()
            .SwaggerDocument();

        builder.Services
            .AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, MigrationKeyAuthenticationHandler>(
                authenticationScheme: AuthSchemeConstants.MigrationPerformingKeyScheme,
                configureOptions: null);
        builder.Services.AddAuthorization();

        builder.Services.Configure<PerformingKeyOptions>(options =>
        {
            options.MigrationPerformingKey = builder.Configuration["MIGRATION_PERFORMING_KEY"]!;
        });

        builder.Services.AddPostgresSharedServices(options =>
        {
            options.ConnectionString = builder.Configuration.GetConnectionString("postgres")!;
        });

        builder.Services.AddMigrationsServices();

        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseFastEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerGen(options =>
            {
                options.Path = "/openapi/{documentName}.json";
            });
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();
        app.UsePathBase("/api");

        app.Run();
    }
}