using Fylum.Migrations.Api.Shared;
using Fylum.Migrations.Client.Listing;
using Fylum.Migrations.Client.Performing;

namespace Fylum.Migrations.Client.Cli;

public class App
{
    private readonly IMigrationsClient _migrationsClient;
    private readonly IPerformingClient _performingClient;

    public App(IMigrationsClient migrationsClient,
        IPerformingClient performingClient)
    {
        _migrationsClient = migrationsClient;
        _performingClient = performingClient;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        Console.WriteLine("App started...");

        var queriedMigrations = await _migrationsClient.GetMigrationsAsync(cancellationToken);
        var migrations = queriedMigrations.Migrations.ToList();
        PrintMigrations(migrations);

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Select migration by ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("number");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" up to which to perform: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        var enteredMigrationNumber = Console.ReadLine()!;
        Console.ForegroundColor = ConsoleColor.White;
        int parsedMigrationNumber = int.TryParse(enteredMigrationNumber, out parsedMigrationNumber) ? parsedMigrationNumber : -1;
        if (parsedMigrationNumber < 0)
            return;
        var selectedMigration = migrations[parsedMigrationNumber - 1];

        var performed = await _performingClient.PerformMigrationsUpToAsync(
            selectedMigration.MigrationId, cancellationToken);

        PrintMigrations(performed.PerformedMigrations.ToList());

        Console.WriteLine("App beendet.");
    }

    private void PrintMigrations(IList<MigrationResponse> migrations)
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
        Console.Write($"[ {index + 1} ]");
        Console.WriteLine($"\t{migration.Name}");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\t{migration.MigrationId}");

        Console.Write("\t");
        Console.ForegroundColor = migration.IsAlreadyPerformed
            ? ConsoleColor.Green
            : ConsoleColor.Red;
        Console.Write(migration.IsAlreadyPerformed ? "Performed" : "Not performed");
        if (migration.IsAlreadyPerformed)
            Console.Write($" {AnsiBrightBlack}{migration.PerformedUtc:G}{AnsiReset}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
    }
}
