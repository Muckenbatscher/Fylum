using Fylum.Core.Application.Query;

namespace Fylum.Folders.Application.GetChildFolders;

public record GetChildFoldersQuery(Guid ParentFolderId) : IQuery<IList<FolderDto>>;