using Fylum.Application;
using Fylum.Users.Domain.Login;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Application.Login;

public class LoginUnitOfWorkFactory : UnitOfWorkFactory<LoginUnitOfWork>
{
    public LoginUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }
}