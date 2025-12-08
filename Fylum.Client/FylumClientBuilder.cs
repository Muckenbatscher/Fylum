namespace Fylum.Client;

public class FylumClientBuilder
{
    private Uri? _baseAddress;
    private HttpMessageHandler? _httpMessageHandler;

    private FylumClientBuilder()
    {
    }

    public static FylumClientBuilder CreateBuilder() => new();

    public FylumClientBuilder WithBaseAddress(string baseAddress)
    {
        var isUri = Uri.IsWellFormedUriString(baseAddress, UriKind.Absolute);
        if (!isUri)
            throw new ArgumentException("The provided base address is not a valid absolute URI.", nameof(baseAddress));
        _baseAddress = new Uri(baseAddress);
        return this;
    }
    public FylumClientBuilder WithBaseAddress(Uri baseAddress)
    {
        ArgumentNullException.ThrowIfNull(baseAddress);
        _baseAddress = baseAddress;
        return this;
    }

    public FylumClientBuilder WithHttpMessageHandler(HttpMessageHandler handler)
    {
        _httpMessageHandler = handler ?? throw new ArgumentNullException(nameof(handler));
        return this;
    }

    public FylumClient Build()
    {
        var httpClient = _httpMessageHandler is not null
            ? new HttpClient(_httpMessageHandler)
            : new HttpClient();
        httpClient.BaseAddress = _baseAddress;
        return new FylumClient(httpClient);
    }
}
