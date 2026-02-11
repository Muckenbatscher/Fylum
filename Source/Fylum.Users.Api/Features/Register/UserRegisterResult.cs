namespace Fylum.Users.Api.Features.Register;

public record UserRegisterResult(Guid UserId, Guid RefreshTokenId, DateTimeOffset RefreshTokenExpiration);