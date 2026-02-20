using Fylum.Users.SharedModels;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

public record TokenRefreshResult(UserDto User, Guid TokenRefreshId, DateTimeOffset RefreshTokenExpiration);