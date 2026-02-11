using Fylum.Core.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Api.Features.Register;

public class UserRegisterUnitOfWorkFactory : UnitOfWorkFactory<UserRegisterUnitOfWork>
{
    public UserRegisterUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) :
        base(serviceScopeFactory)
    {
    }
}