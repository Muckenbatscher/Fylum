using Fylum.Core.Application.Mapping;
using Fylum.Folders.Api.Common.Domain;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Common.Application;

public class FolderMapper : IMapper<Folder, FolderDto>
{
    public FolderDto Map(Folder input)
    {
        return new FolderDto(
            input.Id,
            input.Name,
            input.ParentFolderId);
    }
}
