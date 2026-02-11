using Fylum.Application;
using Fylum.Users.Api.Common.Domain;

namespace Fylum.Users.Api.Features.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IQuery<User>
{
}