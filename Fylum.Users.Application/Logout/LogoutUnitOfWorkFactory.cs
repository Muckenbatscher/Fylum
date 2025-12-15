using Fylum.Application;
using Fylum.Users.Domain.Logout;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Application.Logout;

public class LogoutUnitOfWorkFactory : UnitOfWorkFactory<LogoutUnitOfWork>, ILogoutUnitOfWorkFactory
{
    public LogoutUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }
}
