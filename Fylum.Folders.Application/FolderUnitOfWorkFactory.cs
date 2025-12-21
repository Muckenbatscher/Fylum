using Fylum.Application;
using Fylum.Folders.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Folders.Application;

public class FolderUnitOfWorkFactory : UnitOfWorkFactory<FolderUnitOfWork>, IFolderUnitOfWorkFactory
{
    public FolderUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }
}
