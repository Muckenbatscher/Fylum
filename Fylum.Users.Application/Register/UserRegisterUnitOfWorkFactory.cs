using Fylum.Application;
using Fylum.Users.Domain.Password;
using Fylum.Users.Domain.RefreshTokens;
using Fylum.Users.Domain.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Users.Application.Register;

public class UserRegisterUnitOfWorkFactory : UnitOfWorkFactory, IUserRegisterUnitOfWorkFactory
{
    public UserRegisterUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) :
        base(serviceScopeFactory)
    {
    }

    public UserRegisterUnitOfWork Create()
    {
        CreateScope();

        var transactionFactory = GetTransactionFactory();
        var userRepository = GetScopedService<IUserWithPasswordRepository>();
        var refreshTokenRepository = GetScopedService<IRefreshTokenRepository>();

        return new UserRegisterUnitOfWork(
            transactionFactory,
            userRepository,
            refreshTokenRepository);
    }
}