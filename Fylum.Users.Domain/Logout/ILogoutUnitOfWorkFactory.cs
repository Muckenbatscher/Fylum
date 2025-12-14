using Fylum.Domain.UnitOfWork;

namespace Fylum.Users.Domain.Logout;

public interface ILogoutUnitOfWorkFactory : IUnitOfWorkFactory<LogoutUnitOfWork>
{
}
