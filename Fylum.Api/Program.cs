using FastEndpoints;
using FastEndpoints.Swagger;

namespace Fylum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddFastEndpoints()
                .SwaggerDocument();

            var app = builder.Build();

            app.UseFastEndpoints();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerGen();
            }

            app.UseHttpsRedirection();


            app.Run();
        }
    }
}
