using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Fylum.Api.Shared;
using Fylum.Postgres;
using Fylum.Postgres.Shared;
using Fylum.Users.Api;
using Fylum.Users.Application;
using Fylum.Users.Postgres;
using System.Reflection;
using Scalar.AspNetCore;

namespace Fylum.Api
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
                .AddFastEndpoints(o => o.Assemblies = GetApiEndpointAssemblies())
                .SwaggerDocument();


            builder.Services.AddApiSharedServices(options =>
            {
                options.SigningKey = builder.Configuration["JwtAuth:SigningKey"] ?? string.Empty;
                options.ExpirationInMinutes = int.Parse(builder.Configuration["JwtAuth:ExpirationMinutes"] ?? "1");
            });

            builder.Services.AddPostgresSharedServices(options =>
            {
                options.HostName = builder.Configuration["POSTGRES_HOST"] ?? string.Empty;
                options.Port = int.Parse(builder.Configuration["POSTGRES_PORT"] ?? "0");
                options.DatabaseName = builder.Configuration["POSTGRES_DATABASE"] ?? string.Empty;
                options.Username = builder.Configuration["POSTGRES_USERNAME"] ?? string.Empty;
                options.Password = builder.Configuration["POSTGRES_PASSWORD"] ?? string.Empty;
            });
            builder.Services.AddPostgresServices();

            builder.Services.AddUsersApplicationServices(options =>
            {
                options.IterationCount = int.Parse(builder.Configuration["PasswordHashing:IterationCount"]!);
                options.SaltBitsCount = int.Parse(builder.Configuration["PasswordHashing:SaltBits"]!);
                options.HashedBitsCount = int.Parse(builder.Configuration["PasswordHashing:HashedBits"]!);
                options.PseudoRandomFunction = builder.Configuration["PasswordHashing:PseudoRandomFunction"]!;
            });
            builder.Services.AddUsersPostgresServices();


            var app = builder.Build();

            app.UseAuthentication()
               .UseAuthorization();

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

        private static IEnumerable<Assembly> GetApiEndpointAssemblies()
        {
            yield return Assembly.GetExecutingAssembly();
            yield return typeof(UsersModule).Assembly;
        }
    }
}
