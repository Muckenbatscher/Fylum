using Fylum.Application;
using Fylum.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application.Login
{
    public class UserLoginCommandHandler : IUserLoginCommandHandler
    {
        private readonly IUserWithPasswordRepository _userWithPasswordRepository;
        private readonly IPasswordLoginVerification _loginVerification;

        public UserLoginCommandHandler(IUserWithPasswordRepository userWithPasswordRepository, 
            IPasswordLoginVerification loginVerification)
        {
            _userWithPasswordRepository = userWithPasswordRepository;
            _loginVerification = loginVerification;
        }

        public Result<UserLoginResult> Handle(UserLoginCommand command)
        {
            var user = _userWithPasswordRepository.GetByUsername(command.Username);
            if (user == null)
                return Result.Failure<UserLoginResult>(Error.NotFound);

            bool passwordValid = _loginVerification.VerifyPasswordLogin(
                command.Password, user.Login);

            if (!passwordValid)
                return Result.Failure<UserLoginResult>(Error.Unauthorized);

            return new UserLoginResult(true, user.User.Id);
        }
    }
}
