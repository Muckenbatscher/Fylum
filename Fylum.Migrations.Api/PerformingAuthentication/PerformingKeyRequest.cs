using FastEndpoints;
using Fylum.Migrations.Api.Shared;

namespace Fylum.Migrations.Api.PerformingAuthentication;

public class PerformingKeyRequest
{
    [FromHeader(headerName: PerfomAuthConstants.MigrationPerformingKeyHeaderName, isRequired: false)]
    public string? MigrationPerformingKeyHeader { get; set; }
}
