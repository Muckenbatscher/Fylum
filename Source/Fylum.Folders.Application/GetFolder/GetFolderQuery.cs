using Fylum.Core.Application.Query;

namespace Fylum.Folders.Application.GetFolder;

public record GetFolderQuery(Guid FolderId) : IQuery<FolderDto>;
