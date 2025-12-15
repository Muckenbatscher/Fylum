using Fylum.Migrations.Api.Shared;
using Microsoft.Extensions.Options;

namespace Fylum.Migrations.Client.Auth;

public class PerformingKeyAuthHeaderHandler : DelegatingHandler
{
    private readonly string _performingKey;
    public PerformingKeyAuthHeaderHandler(IOptions<ClientOptions> clientOptions)
    {
        _performingKey = clientOptions.Value.MigrationPerformingKey;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(_performingKey))
        {
            var performingKeyHeader = PerfomAuthConstants.MigrationPerformingKeyHeaderName;
            request.Headers.Add(performingKeyHeader, $"Key: {_performingKey}");
        }

        var response = await base.SendAsync(request, cancellationToken);
        return response;
    }
}
