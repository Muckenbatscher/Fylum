namespace Fylum.Folders.SharedModels;

public record CreateFolderResponse(Guid Id, string Name, Guid ParentFolderId);
