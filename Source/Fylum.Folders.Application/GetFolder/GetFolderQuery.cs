using Fylum.Application;

namespace Fylum.Folders.Application.GetFolder;

public record GetFolderQuery(Guid FolderId) : IQuery<FolderDto>;
