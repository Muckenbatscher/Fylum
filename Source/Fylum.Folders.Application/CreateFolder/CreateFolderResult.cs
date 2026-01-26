namespace Fylum.Folders.Application.CreateFolder;

public record CreateFolderResult(Guid Id, string Name, Guid ParentFolderId);
