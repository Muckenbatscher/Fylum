using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Fylum.Api.Authentication;
using Fylum.Api.EndpointRouteDefinitions;
using Fylum.Application;
using Fylum.PostgreSql;

namespace Fylum.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddAuthenticationJwtBearer(o => o.SigningKey = builder.Configuration["JwtAuth:SigningKey"])
                .AddAuthorization()
                .AddFastEndpoints()
                .SwaggerDocument();
            builder.Services.AddEndpointRouteDefinitions();

            builder.Services.AddPostgreSqlSharedServices(options =>
            {
                options.HostName = builder.Configuration["DbConnection:Host"]!;
                options.Port = int.Parse(builder.Configuration["DbConnection:Port"]!);
                options.DatabaseName = builder.Configuration["DbConnection:Database"]!;
                options.Username = builder.Configuration["DbConnection:Username"]!;
                options.Password = builder.Configuration["DbConnection:Password"]!;
            });
            builder.Services.AddPostgreSqlServices();
            builder.Services.AddApplicationServices();

            builder.Services.Configure<JwtAuthOptions>(options =>
            {
                options.SigningKey = builder.Configuration["JwtAuth:SigningKey"]!;
                options.UserIdClaim = builder.Configuration["JwtAuth:UserIdClaim"]!;
                options.ExpirationInMinutes = int.Parse(builder.Configuration["JwtAuth:ExpirationMinutes"]!);
            });

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
