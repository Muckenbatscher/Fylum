namespace Fylum.Migrations.Api.PerformingAuthentication;

public interface IPerformingKeyRequestValidator
{
    bool IsAuthenticated(PerformingKeyRequest request);
}
