namespace Fylum.Folders.Api.Models;

public record CreateFolderRequest(string Name, Guid ParentFolderId);
