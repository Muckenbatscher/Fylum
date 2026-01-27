using Fylum.Application;
using Fylum.Users.Domain.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Application.Register;

public class UserRegisterUnitOfWorkFactory : UnitOfWorkFactory<UserRegisterUnitOfWork>
{
    public UserRegisterUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) :
        base(serviceScopeFactory)
    {
    }
}