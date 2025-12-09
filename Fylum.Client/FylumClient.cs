namespace Fylum.Client;

public class FylumClient : IFylumClient
{
    private readonly HttpClient _httpClient;

    public FylumClient(HttpClient httpClient)
    {
        _httpClient = httpClient 
            ?? throw new ArgumentNullException(nameof(httpClient));
    }
}