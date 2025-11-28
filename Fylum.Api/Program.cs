using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Fylum.Api.Shared;
using Fylum.Migrations.Api;
using Fylum.Postgres;
using Fylum.Postgres.Shared;
using Fylum.Users.Application;
using Fylum.Users.Postgres;
using System.Reflection;

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
                options.SigningKey = builder.Configuration["JwtAuth:SigningKey"]!;
                options.ExpirationInMinutes = int.Parse(builder.Configuration["JwtAuth:ExpirationMinutes"]!);
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

            builder.Services.AddUsersApplicationServices(options =>
            {
                options.IterationCount = int.Parse(builder.Configuration["PasswordHashing:IterationCount"]!);
                options.SaltBitsCount = int.Parse(builder.Configuration["PasswordHashing:SaltBits"]!);
                options.HashedBitsCount = int.Parse(builder.Configuration["PasswordHashing:HashedBits"]!);
                options.PseudoRandomFunction = builder.Configuration["PasswordHashing:PseudoRandomFunction"]!;
            });
            builder.Services.AddUsersPostgresServices();

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

        private static IEnumerable<Assembly> GetApiEndpointAssemblies()
        {
            yield return Assembly.GetExecutingAssembly();
            yield return typeof(MigrationsApiModule).Assembly;
        }
    }
}
