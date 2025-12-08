namespace Fylum.Client;

public class FylumClient : IFylumClient
{
    private readonly HttpClient _httpClient;
    private readonly ClientOptions _options;

    public FylumClient(HttpClient httpClient, ClientOptions options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _options = options ?? throw new ArgumentNullException(nameof(options));

        if (_httpClient.BaseAddress == null)
            _httpClient.BaseAddress = new Uri(_options.BaseUrl);
    }
}