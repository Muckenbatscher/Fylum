namespace Fylum.Folders.Application;

public record FolderDto(Guid Id, string Name, Guid ParentFolderId);