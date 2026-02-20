using Fylum.Core.Application.Command;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.CreateFolder;

public record CreateFolderCommand(string Name, Guid ParentFolderId) : ICommand<FolderDto>;
