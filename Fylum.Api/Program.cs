using FastEndpoints;
using FastEndpoints.Swagger;
using Fylum.EndpointRouteDefinitions;

namespace Fylum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddFastEndpoints()
                .SwaggerDocument();
            builder.Services.AddEndpointRouteDefinitions();

            var app = builder.Build();

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
