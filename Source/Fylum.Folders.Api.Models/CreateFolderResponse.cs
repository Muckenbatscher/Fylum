namespace Fylum.Folders.Api.Models;

public record CreateFolderResponse(Guid Id, string Name, Guid ParentFolderId);
