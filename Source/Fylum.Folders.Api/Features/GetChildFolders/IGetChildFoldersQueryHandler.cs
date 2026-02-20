using Fylum.Core.Application.Query;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.GetChildFolders;

public interface IGetChildFoldersQueryHandler : IQueryHandler<GetChildFoldersQuery, IList<FolderDto>>
{
}
