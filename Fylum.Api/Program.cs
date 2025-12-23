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
            .AddAuthenticationJwtBearer(o => o.SigningKey = builder.Configuration.GetValue<string>("JwtAuth:SigningKey")!)
            .AddAuthorization()
            .AddFastEndpoints(o => o.Assemblies = GetApiEndpointAssemblies())
            .SwaggerDocument();

        builder.Services.AddApiSharedServices(options =>
        {
            options.SigningKey = builder.Configuration.GetValue<string>("JwtAuth:SigningKey")!;
            options.AccessTokenExpirationInMinutes = builder.Configuration.GetValue("JwtAuth:AccessTokenExpirationMinutes", 1);
        });

        builder.Services.AddPostgresSharedServices(options =>
        {
            options.ConnectionString = builder.Configuration.GetConnectionString("postgres")
                ?? string.Empty;
        });

        builder.Services.AddUsersApplicationServices(passwordHashOptions =>
        {
            passwordHashOptions.IterationCount = builder.Configuration.GetValue<int>("PasswordHashing:IterationCount");
            passwordHashOptions.SaltBitsCount = builder.Configuration.GetValue<int>("PasswordHashing:SaltBits");
            passwordHashOptions.HashedBitsCount = builder.Configuration.GetValue<int>("PasswordHashing:HashedBits");
            passwordHashOptions.PseudoRandomFunction = builder.Configuration.GetValue<string>("PasswordHashing:PseudoRandomFunction")!;
        },
        refreshTokenOptions =>
        {
            var expirationDays = builder.Configuration.GetValue("RefreshToken:RefreshTokenExpirationDays", 1);
            refreshTokenOptions.RefreshTokenExpirationInDays = expirationDays;
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