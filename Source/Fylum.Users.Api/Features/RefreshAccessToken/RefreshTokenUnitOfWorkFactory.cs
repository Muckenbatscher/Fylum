using Fylum.Core.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Api.Features.RefreshAccessToken;

internal class RefreshTokenUnitOfWorkFactory : UnitOfWorkFactory<RefreshTokenUnitOfWork>
{
    public RefreshTokenUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }
}