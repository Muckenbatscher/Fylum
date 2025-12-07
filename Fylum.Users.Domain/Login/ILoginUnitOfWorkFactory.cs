using Fylum.Domain.UnitOfWork;

namespace Fylum.Users.Domain.Login;

public interface ILoginUnitOfWorkFactory : IUnitOfWorkFactory<LoginUnitOfWork>
{
}