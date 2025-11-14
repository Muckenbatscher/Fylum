namespace Fylum.Migrations.Api.Shared;

public class EndpointRoutes
{
    public static string MigrationsBaseRoute => "migrations";
    public static string MigrationsPerformUpToRoute => "migrations/performUpTo";
    public static string MigrationsPerformAllRoute => "migrations/performAll";
    public static string MigrationsPerformMinimallyRequiredRoute => "migrations/performMinimallyRequired";
}
