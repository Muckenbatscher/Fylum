using Aspire.Hosting;
using Aspire.Hosting.Testing;

namespace Fylum.EndToEnd;

public record DistributedApplicationContainer(DistributedApplication DistributedApp) : IDisposable
{
    public HttpClient CreateHttpClient(HttpClientType clientType)
        => DistributedApp.CreateHttpClient(clientType.Name);

    public void Dispose()
        => DistributedApp.Dispose();
    public async Task DisposeAsync()
        => await DistributedApp.DisposeAsync();
}
