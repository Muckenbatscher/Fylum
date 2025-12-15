namespace Fylum.Migrations.Client.Performing;

public class PerformingClient : IPerformingClient
{
    private readonly HttpClient _httpClient;

    public PerformingClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
