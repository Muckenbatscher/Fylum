using Fylum.Core.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Folders.Api.Common.Domain;

public class FolderUnitOfWorkFactory : UnitOfWorkFactory<FolderUnitOfWork>
{
    public FolderUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }
}
