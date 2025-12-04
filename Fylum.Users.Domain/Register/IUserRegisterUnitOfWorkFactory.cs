using Fylum.Domain.UnitOfWork;

namespace Fylum.Users.Domain.Register;

public interface IUserRegisterUnitOfWorkFactory : IUnitOfWorkFactory<UserRegisterUnitOfWork>
{
}