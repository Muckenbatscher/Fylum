using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Fylum.Api.Shared;
using Fylum.Postgres.Shared;
using Fylum.Users.Api;
using Fylum.Users.Application;
using Fylum.Users.Postgres;
using Scalar.AspNetCore;
using System.Reflection;

namespace Fylum.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults(); // from Aspire Service Defaults

        builder.Services
            .AddAuthenticationJwtBearer(o => o.SigningKey = builder.Configuration["JwtAuth:SigningKey"])
            .AddAuthorization()
            .AddFastEndpoints(o => o.Assemblies = GetApiEndpointAssemblies())
            .SwaggerDocument();

        builder.Services.AddApiSharedServices(options =>
        {
            options.SigningKey = builder.Configuration["JwtAuth:SigningKey"] ?? string.Empty;
            options.AccessTokenExpirationInMinutes = int.Parse(builder.Configuration["JwtAuth:AccessTokenExpirationMinutes"] ?? "1");
        });

        builder.Services.AddPostgresSharedServices(options =>
        {
            options.HostName = builder.Configuration["POSTGRES_HOST"] ?? string.Empty;
            options.Port = int.Parse(builder.Configuration["POSTGRES_PORT"] ?? "0");
            options.DatabaseName = builder.Configuration["POSTGRES_DATABASENAME"] ?? string.Empty;
            options.Username = builder.Configuration["POSTGRES_USERNAME"] ?? string.Empty;
            options.Password = builder.Configuration["POSTGRES_PASSWORD"] ?? string.Empty;
        });

        builder.Services.AddUsersApplicationServices(passwordHashOptions =>
        {
            passwordHashOptions.IterationCount = int.Parse(builder.Configuration["PasswordHashing:IterationCount"]!);
            passwordHashOptions.SaltBitsCount = int.Parse(builder.Configuration["PasswordHashing:SaltBits"]!);
            passwordHashOptions.HashedBitsCount = int.Parse(builder.Configuration["PasswordHashing:HashedBits"]!);
            passwordHashOptions.PseudoRandomFunction = builder.Configuration["PasswordHashing:PseudoRandomFunction"]!;
        },
        refreshTokenOptions =>
        {
            var configValue = builder.Configuration["RefreshToken:RefreshTokenExpirationDays"];
            refreshTokenOptions.RefreshTokenExpirationInDays = configValue != null ? int.Parse(configValue) : 1;
        });
        builder.Services.AddUsersPostgresServices();

        var app = builder.Build();

        app.UseAuthentication()
           .UseAuthorization();

        app.UseFastEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerGen(options => options.Path = "/openapi/{documentName}.json");
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();
        app.UsePathBase("/api");

        app.Run();
    }

    private static IEnumerable<Assembly> GetApiEndpointAssemblies()
    {
        yield return Assembly.GetExecutingAssembly();
        yield return typeof(UsersModule).Assembly;
    }
}