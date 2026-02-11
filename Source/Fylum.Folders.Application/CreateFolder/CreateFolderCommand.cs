using Fylum.Core.Application.Command;

namespace Fylum.Folders.Application.CreateFolder;

public record CreateFolderCommand(string Name, Guid ParentFolderId) : ICommand<CreateFolderResult>;
