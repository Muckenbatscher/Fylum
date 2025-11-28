namespace Fylum.Api.Shared.JwtAuthentication;

public interface IJwtAuthService
{
    string BuildToken(Guid userId);
}