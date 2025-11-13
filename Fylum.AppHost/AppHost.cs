internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var database = builder.AddPostgres("postgres")
            .WithEnvironment("POSTGRES_DB", "fylum")
            .AddDatabase("fylum");

        var api = builder.AddProject<Projects.Fylum_Api>("api");

        builder.Build().Run();
    }
}