namespace Fylum.Client;

public class ClientOptions
{
    public Uri BaseUri
    {
        get => field ?? throw new InvalidOperationException($"{nameof(BaseUri)} needs to be set first");
        set;
    }

    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}
