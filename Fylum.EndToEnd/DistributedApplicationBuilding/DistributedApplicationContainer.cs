using Aspire.Hosting;
using Aspire.Hosting.Testing;

namespace Fylum.EndToEnd.DistributedApplicationBuilding;

public record DistributedApplicationContainer(DistributedApplication DistributedApp) : IDisposable, IAsyncDisposable
{
    const string ApiClientResourceName = "api";
    const string EndpointScheme = "https";

    public HttpClient CreateApiHttpClient()
        => DistributedApp.CreateHttpClient(ApiClientResourceName, EndpointScheme);

    public Uri GetApiBaseUri()
        => DistributedApp.GetEndpoint(ApiClientResourceName, EndpointScheme);

    public void Dispose()
        => DistributedApp.Dispose();
    public async ValueTask DisposeAsync()
        => await DistributedApp.DisposeAsync();
}
