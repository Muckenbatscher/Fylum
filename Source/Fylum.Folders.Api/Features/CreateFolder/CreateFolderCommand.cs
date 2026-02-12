using Fylum.Core.Application.Command;

namespace Fylum.Folders.Api.Features.CreateFolder;

public record CreateFolderCommand(string Name, Guid ParentFolderId) : ICommand<CreateFolderResult>;
