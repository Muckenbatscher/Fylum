using Fylum.Core.Application.Query;
using Fylum.Users.SharedModels;

namespace Fylum.Users.Api.Features.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IQuery<UserDto>
{
}