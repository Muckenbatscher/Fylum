namespace Fylum.Migrations.Winforms.MainWindow;

public class MigrationRow
{
    public MigrationRow(Guid id, string name, bool isPerformed, DateTimeOffset? performedTimestamp)
    {
        Id = id;
        Name = name;
        IsPerformed = isPerformed;
        PerformedTimestamp = performedTimestamp;
    }

    public string Name { get; }
    public int ScriptCount => 0;

    public Guid Id { get; }
    public bool IsPerformed { get; }
    public DateTimeOffset? PerformedTimestamp { get; }

    public DateTime? LocalPerformedTimestamp
        => PerformedTimestamp?.ToLocalTime().DateTime;
}