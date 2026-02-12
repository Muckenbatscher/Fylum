using Fylum.Core.Application.Query;
using Fylum.Core.Application.Results;
using Fylum.Core.Domain;
using Fylum.Folders.Api.Common.Application;
using Fylum.Folders.Api.Common.Domain;

namespace Fylum.Folders.Api.Features.GetChildFolders;

public class GetChildFoldersQueryHandler : IQueryHandler<GetChildFoldersQuery, IList<FolderDto>>
{
    private readonly IUnitOfWorkFactory<FolderUnitOfWork> _unitOfWorkFactory;

    public GetChildFoldersQueryHandler(IUnitOfWorkFactory<FolderUnitOfWork> unitOfWorkFactory)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public Result<IList<FolderDto>> Handle(GetChildFoldersQuery query)
    {
        using var unitOfWork = _unitOfWorkFactory.Create();
        var folder = unitOfWork.FolderRepository.GetById(query.ParentFolderId);

        if (folder == null)
            return Result.Failure(Error.NotFound);

        var childFolders = unitOfWork.FolderRepository.GetChildFolders(query.ParentFolderId);

        var dtos = childFolders.Select(MapToDto).ToList();
        return Result.Success<IList<FolderDto>>(dtos);
    }

    private FolderDto MapToDto(Folder folder) => new FolderDto(folder.Id, folder.Name, folder.ParentFolderId);
}
