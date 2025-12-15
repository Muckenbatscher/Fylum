using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Client.Listing;

namespace Fylum.Migrations.Client.Demo;

public class App
{
    private readonly IMigrationsClient _migrationsClient;

    public App(IMigrationsClient migrationsClient)
    {
        _migrationsClient = migrationsClient;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        Console.WriteLine("App gestartet...");

        var queriedMigrations = await _migrationsClient.GetMigrationsAsync(cancellationToken);
        var migrations = queriedMigrations.Migrations.ToList();
        PrintMigrations(migrations);

        Console.WriteLine("App beendet.");
    }

    private void PrintMigrations(IReadOnlyList<MigrationResponse> migrations)
    {
        for (int index = 0; index < migrations.Count; index++)
        {
            PrintMigration(migrations[index], index);
            Console.WriteLine();
        }
    }
    private void PrintMigration(MigrationResponse migration, int index)
    {
        string AnsiBrightBlack = "\x1b[90m";
        string AnsiReset = "\x1b[0m";

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"[ {index} ]");
        Console.WriteLine($"\t{migration.Name}");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\t{migration.MigrationId}");

        Console.Write("\t");
        Console.ForegroundColor = migration.IsAlreadyPerformed 
            ? ConsoleColor.Green 
            : ConsoleColor.Red;
        Console.Write(migration.IsAlreadyPerformed ? "Performed" : "Not performed");
        if (migration.IsAlreadyPerformed)
            Console.Write($" {AnsiBrightBlack}{DateTime.Now:G}{AnsiReset}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
    }
}
