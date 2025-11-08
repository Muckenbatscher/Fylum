using Fylum.Application;
using Fylum.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application.GetUser
{
    public class GetUserCommandHandler : IGetUserCommandHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result<User> Handle(GetUserCommand command)
        {
            var user = _userRepository.GetById(command.UserId);
            if (user is null)
                return Result.Failure<User>(Error.NotFound);

            return user;
        }
    }
}
