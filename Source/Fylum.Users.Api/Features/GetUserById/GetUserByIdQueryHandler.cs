using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Users.Api.Common.Domain;
using Fylum.Users.SharedModels;

namespace Fylum.Users.Api.Features.GetUserById;

public class GetUserByIdQueryHandler : IGetUserByIdQueryHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper<User, UserDto> _mapper;

    public GetUserByIdQueryHandler(
        IUserRepository userRepository,
        IMapper<User, UserDto> mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Result<UserDto> Handle(GetUserByIdQuery command)
    {
        var user = _userRepository.GetById(command.UserId);
        if (user is null)
            return Result.Failure<UserDto>(Error.NotFound);

        return _mapper.Map(user);
    }
}