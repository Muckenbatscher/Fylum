using Fylum.Application;

namespace Fylum.Folders.Application.GetChildFolders;

public record GetChildFoldersQuery(Guid ParentFolderId) : IQuery<IList<FolderDto>>;