using Fylum.Application;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application.Register
{
    public class UserRegisterCommandHandler : IUserRegisterCommandHandler
    {
        private readonly IUserRegisterUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPasswordHashCalculator _hashCalculator;

        public UserRegisterCommandHandler(IUserRegisterUnitOfWorkFactory unitOfWorkFactory, 
            IPasswordHashCalculator hashCalculator)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _hashCalculator = hashCalculator;
        }

        public Result<UserRegisterResult> Handle(UserRegisterCommand command)
        {
            using var unitOfWork = _unitOfWorkFactory.Create();

            var repository = unitOfWork.UserWithPasswordRepository;
            var existingUser = repository.GetByUsername(command.Username);
            if (existingUser != null)
                return Result.Failure<UserRegisterResult>(Error.Conflict);

            var salt = _hashCalculator.CreateRandomSalt();
            var passwordHash = _hashCalculator.Hash(command.Password, salt);
            var userLogin = UserWithPasswordLogin.CreateNew(command.Username, true, passwordHash, salt);
            repository.Create(userLogin);
            unitOfWork.Commit();

            return new UserRegisterResult(userLogin.User.Id); ;
        }
    }
}
