using Fylum.Application;
using Fylum.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application.Register
{
    public class UserRegisterCommandHandler : IUserRegisterCommandHandler
    {
        private readonly IUserWithPasswordRepository _userWithPasswordRepository;
        private readonly IPasswordHashCalculator _hashCalculator;

        public UserRegisterCommandHandler(IUserWithPasswordRepository userWithPasswordRepository, 
            IPasswordHashCalculator hashCalculator)
        {
            _userWithPasswordRepository = userWithPasswordRepository;
            _hashCalculator = hashCalculator;
        }

        public Result<UserRegisterResult> Handle(UserRegisterCommand command)
        {
            var existingUser = _userWithPasswordRepository.GetByUsername(command.Username);
            if (existingUser != null)
                return Result.Failure<UserRegisterResult>(Error.Conflict);

            var salt = _hashCalculator.CreateRandomSalt();
            var passwordHash = _hashCalculator.Hash(command.Password, salt);
            var userLogin = UserWithPasswordLogin.CreateNew(command.Username, true, passwordHash, salt);
            _userWithPasswordRepository.Create(userLogin);
            
            return new UserRegisterResult(userLogin.User.Id); ;
        }
    }
}
