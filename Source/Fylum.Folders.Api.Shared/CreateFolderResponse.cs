namespace Fylum.Folders.Api.Shared;

public record CreateFolderResponse(Guid Id, string Name, Guid ParentFolderId);
