namespace Fylum.Folders.SharedModels;

public record CreateFolderRequest(string Name, Guid ParentFolderId);
