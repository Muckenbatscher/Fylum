using Fylum.Application;
using Fylum.Users.Domain.RefreshTokens;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Application.RefreshTokens;

internal class RefreshTokenUnitOfWorkFactory : UnitOfWorkFactory<RefreshTokenUnitOfWork>
{
    public RefreshTokenUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }
}