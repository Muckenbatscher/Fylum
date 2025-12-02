using Microsoft.Extensions.Options;

namespace Fylum.Migrations.Api.PerformingAuthentication;

public class PerformingKeyRequestValidator : IPerformingKeyRequestValidator
{
    private readonly PerformingKeyOptions _keyOptions;

    public PerformingKeyRequestValidator(IOptions<PerformingKeyOptions> keyOptions)
    {
        _keyOptions = keyOptions.Value;
    }

    public bool IsAuthenticated(PerformingKeyRequest request)
        => request.MigrationPerformingKeyHeader == ExpextedKeyHeader;

    private string ExpextedKeyHeader
        => $"Key: {_keyOptions.MigrationPerformingKey}";
}
