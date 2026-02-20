using Fylum.Users.SharedModels;

namespace Fylum.Users.Api.Features.Register;

public record UserRegisterResult(
    UserDto User,
    Guid RefreshTokenId,
    DateTimeOffset RefreshTokenExpiration);