namespace Fylum.Folders.Api.Shared;

public record CreateFolderRequest(string Name, Guid ParentFolderId);
