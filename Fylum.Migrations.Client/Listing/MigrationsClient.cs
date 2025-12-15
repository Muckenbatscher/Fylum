namespace Fylum.Migrations.Client.Listing;

public class MigrationsClient : IMigrationsClient
{
    private readonly HttpClient _httpClient;

    public MigrationsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
