using Fylum.Core.Application.Mapping;
using Fylum.Users.Api.Common.Domain;
using Fylum.Users.SharedModels;

namespace Fylum.Users.Api.Common.Application;

public class UserMapper : IMapper<User, UserDto>
{
    public UserDto Map(User input)
    {
        return new UserDto(input.Id,
            input.Username,
            input.IsActive);
    }
}
