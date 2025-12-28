namespace Fylum.Migrations.Api.PerformingAuthentication;

public interface IPerformingKeyRequestValidator
{
    bool IsAuthenticated(HttpRequest request);
}