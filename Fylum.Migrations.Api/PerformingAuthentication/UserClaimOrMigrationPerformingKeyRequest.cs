using FastEndpoints;

namespace Fylum.Migrations.Api.PerformingAuthentication;

public class UserClaimOrMigrationPerformingKeyRequest
{
    [FromClaim(claimType: PerfomAuthConstants.UserIdClaim, isRequired: false)]
    public Guid? UserId { get; set; }


    [FromHeader(headerName: PerfomAuthConstants.MigrationPerformingKeyHeaderName, isRequired: false)]
    public string? MigrationPerformingKey { get; set; }

    public bool IsAuthenticated
    { 
        get
        {
            var migrationPerformingKeySet = !string.IsNullOrEmpty(MigrationPerformingKey);
            var userIdSet = UserId.HasValue && !UserId.Value.Equals(Guid.Empty);
            return migrationPerformingKeySet || userIdSet;
        } 
    }
}
