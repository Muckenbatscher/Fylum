using Fylum.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application
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

        public UserLoginResult Handle(UserLoginCommand command)
        {
            var user = _userWithPasswordRepository.GetByUsername(command.Parameter.Username);
            if (user == null)
                return new UserLoginResult(false, null);

            bool passwordValid = _loginVerification.VerifyPasswordLogin(
                command.Parameter.Password, user.Login);

            if (!passwordValid)
                return new UserLoginResult(false, null);
            
            return new UserLoginResult(true, user.User.Id);
        }
    }
}
