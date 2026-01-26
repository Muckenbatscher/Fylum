namespace Fylum.Folders.Api.Shared;

public record GetFolderResponse(Guid FolderId, string Name, Guid ParentFolderId);
