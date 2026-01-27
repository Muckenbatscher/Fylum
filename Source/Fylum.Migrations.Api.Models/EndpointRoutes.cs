namespace Fylum.Migrations.Api.Models;

public class EndpointRoutes
{
    public static string MigrationsBaseRoute => "migrations";
    public static string MigrationsPerformUpToRoute => "migrations/performUpTo";
    public static string MigrationsPerformAllRoute => "migrations/performAll";
}