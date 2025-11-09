using Fylum.Domain.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Application
{
    public abstract class UnitOfWorkFactory : IDisposable
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        private IServiceScope? sharedScope;

        public UnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected void CreateScope()
        {
            sharedScope = CreateNewScope();
        }
        private IServiceScope CreateNewScope()
            => _serviceScopeFactory.CreateScope();

        protected IUnitOfWorkTransactionFactory GetTransactionFactory()
            => GetScopedService<IUnitOfWorkTransactionFactory>();
        protected T GetScopedService<T>() where T : notnull
        {
            var scope = sharedScope ?? CreateNewScope();
            return scope.ServiceProvider.GetRequiredService<T>();
        }

        public void Dispose() 
            => DisposeScope();

        private void DisposeScope()
        {
            sharedScope?.Dispose();
            sharedScope = null;
        }
    }
}
