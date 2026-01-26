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

        Console.WriteInColor("Select migration by ", ConsoleColor.White);
        Console.WriteInColor("number", ConsoleColor.Blue);
        Console.WriteInColor(" up to which to perform: ", ConsoleColor.White);

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
    }

    private static void PrintMigrations(IList<MigrationResponse> migrations)
    {
        for (int index = 0; index < migrations.Count; index++)
        {
            PrintMigration(migrations[index], index);
            Console.WriteLine();
        }
    }
    private static void PrintMigration(MigrationResponse migration, int index)
    {
        const int indexWhiteSpaceChars = 8;
        string AnsiBrightBlack = "\x1b[90m";
        string AnsiReset = "\x1b[0m";

        Console.WriteRightPaddedInColor($"[ {index + 1} ]",
            indexWhiteSpaceChars, ConsoleColor.Blue);
        Console.WriteInColor(migration.Name, ConsoleColor.Blue);
        Console.WriteLine();

        Console.WriteLeftPaddednColor(migration.MigrationId.ToString(),
            indexWhiteSpaceChars, ConsoleColor.White);
        Console.WriteLine();

        var performedState = migration.IsAlreadyPerformed
            ? "Performed" : "Not performed";
        var performedColor = migration.IsAlreadyPerformed
            ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLeftPaddednColor(performedState,
            indexWhiteSpaceChars, performedColor);
        Console.ForegroundColor = migration.IsAlreadyPerformed
            ? ConsoleColor.Green
            : ConsoleColor.Red;
        if (migration.IsAlreadyPerformed)
            Console.Write($" {AnsiBrightBlack}{migration.PerformedUtc:G}{AnsiReset}");
        Console.WriteLine();
    }
}
