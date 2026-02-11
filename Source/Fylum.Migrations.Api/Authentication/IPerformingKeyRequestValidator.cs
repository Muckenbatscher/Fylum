namespace Fylum.Migrations.Api.Authentication;

public interface IPerformingKeyRequestValidator
{
    bool IsAuthenticated(HttpRequest request);
}