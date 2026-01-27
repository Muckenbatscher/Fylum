namespace Fylum.Folders.Api.Models;

public record GetFolderResponse(Guid FolderId, string Name, Guid ParentFolderId);
