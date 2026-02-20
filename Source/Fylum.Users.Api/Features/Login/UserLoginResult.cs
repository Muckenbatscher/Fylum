using Fylum.Users.SharedModels;

namespace Fylum.Users.Api.Features.Login;

public record UserLoginResult(UserDto User, Guid RefreshTokenId, DateTimeOffset RefreshTokenExpiration);