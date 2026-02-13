using Fylum.Core.Application.Command;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.CreateFolder;

public interface ICreateFolderCommandHandler : ICommandHandler<CreateFolderCommand, FolderDto>
{
}
