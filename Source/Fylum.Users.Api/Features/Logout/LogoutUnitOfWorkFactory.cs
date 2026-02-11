using Fylum.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Api.Features.Logout;

public class LogoutUnitOfWorkFactory : UnitOfWorkFactory<LogoutUnitOfWork>
{
    public LogoutUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }
}
