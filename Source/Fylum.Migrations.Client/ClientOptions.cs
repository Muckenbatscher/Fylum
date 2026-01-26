namespace Fylum.Migrations.Client;

public class ClientOptions
{
    public Uri BaseUri
    {
        get => field ?? throw new InvalidOperationException($"{nameof(BaseUri)} needs to be set first");
        set;
    }

    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);

    public string MigrationPerformingKey { get; set; } = string.Empty;
}
