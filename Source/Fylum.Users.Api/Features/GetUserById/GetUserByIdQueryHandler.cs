using Fylum.Application;
using Fylum.Users.Api.Common.Domain;

namespace Fylum.Users.Api.Features.GetUserById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Result<User> Handle(GetUserByIdQuery command)
    {
        var user = _userRepository.GetById(command.UserId);
        if (user is null)
            return Result.Failure<User>(Error.NotFound);

        return user;
    }
}