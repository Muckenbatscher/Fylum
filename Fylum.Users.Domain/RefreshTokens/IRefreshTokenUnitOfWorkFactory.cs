using Fylum.Domain.UnitOfWork;

namespace Fylum.Users.Domain.RefreshTokens;

public interface IRefreshTokenUnitOfWorkFactory : IUnitOfWorkFactory<RefreshTokenUnitOfWork>
{
}