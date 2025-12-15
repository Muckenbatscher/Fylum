namespace Fylum.Users.Api.Shared;

public record UserResponse(Guid Id, string Username, bool IsActive);
