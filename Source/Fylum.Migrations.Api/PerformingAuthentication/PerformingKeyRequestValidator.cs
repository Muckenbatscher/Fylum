using Fylum.Migrations.Api.Shared;
using Microsoft.Extensions.Options;

namespace Fylum.Migrations.Api.PerformingAuthentication;

public class PerformingKeyRequestValidator : IPerformingKeyRequestValidator
{
    private readonly PerformingKeyOptions _keyOptions;

    public PerformingKeyRequestValidator(IOptions<PerformingKeyOptions> keyOptions)
    {
        _keyOptions = keyOptions.Value;
    }

    public bool IsAuthenticated(HttpRequest request)
    {
        var headerName = PerfomAuthConstants.MigrationPerformingKeyHeaderName;
        if (!request.Headers.TryGetValue(headerName, out var providedKey))
            return false;

        return providedKey == ExpextedKeyHeader;
    }

    private string ExpextedKeyHeader
        => $"Key: {_keyOptions.MigrationPerformingKey}";
}