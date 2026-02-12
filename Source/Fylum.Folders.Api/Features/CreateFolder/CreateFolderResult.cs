namespace Fylum.Folders.Api.Features.CreateFolder;

public record CreateFolderResult(Guid Id, string Name, Guid ParentFolderId);
