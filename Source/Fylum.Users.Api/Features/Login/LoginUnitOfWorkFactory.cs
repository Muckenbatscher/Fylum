using Fylum.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Api.Features.Login;

public class LoginUnitOfWorkFactory : UnitOfWorkFactory<LoginUnitOfWork>
{
    public LoginUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }
}