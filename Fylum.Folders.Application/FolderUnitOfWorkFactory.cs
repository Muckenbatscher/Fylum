using Fylum.Application;
using Fylum.Folders.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Folders.Application;

public class FolderUnitOfWorkFactory : UnitOfWorkFactory<FolderUnitOfWork>
{
    public FolderUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }
}
