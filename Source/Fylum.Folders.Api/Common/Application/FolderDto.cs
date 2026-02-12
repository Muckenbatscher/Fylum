namespace Fylum.Folders.Api.Common.Application;

public record FolderDto(Guid Id, string Name, Guid ParentFolderId);