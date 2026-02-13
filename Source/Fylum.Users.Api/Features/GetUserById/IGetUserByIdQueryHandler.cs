using Fylum.Core.Application.Query;
using Fylum.Users.SharedModels;

namespace Fylum.Users.Api.Features.GetUserById;

public interface IGetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
{
}
