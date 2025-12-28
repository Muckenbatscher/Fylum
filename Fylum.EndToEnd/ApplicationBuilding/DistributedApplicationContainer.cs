using Aspire.Hosting;
using Aspire.Hosting.Testing;

namespace Fylum.EndToEnd.ApplicationBuilding;

public record DistributedApplicationContainer(DistributedApplication DistributedApp) : IDisposable
{
    const string ApiClientResourceName = "api";
    const string EndpointScheme = "https";

    public HttpClient CreateApiHttpClient()
        => DistributedApp.CreateHttpClient(ApiClientResourceName, EndpointScheme);

    public Uri GetApiBaseUri()
        => DistributedApp.GetEndpoint(ApiClientResourceName, EndpointScheme);

    public void Dispose()
        => DistributedApp.Dispose();
    public async Task DisposeAsync()
        => await DistributedApp.DisposeAsync();
}
