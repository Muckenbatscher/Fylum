namespace Fylum.Folders.SharedModels;

public record GetFolderResponse(Guid FolderId, string Name, Guid ParentFolderId);
