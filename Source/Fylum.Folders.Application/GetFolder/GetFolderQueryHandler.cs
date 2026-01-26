using Fylum.Application;
using Fylum.Domain.UnitOfWork;
using Fylum.Folders.Domain;

namespace Fylum.Folders.Application.GetFolder;

public class GetFolderQueryHandler : IQueryHandler<GetFolderQuery, FolderDto>
{
    private readonly IUnitOfWorkFactory<FolderUnitOfWork> _unitOfWorkFactory;

    public GetFolderQueryHandler(IUnitOfWorkFactory<FolderUnitOfWork> unitOfWorkFactory)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public Result<FolderDto> Handle(GetFolderQuery query)
    {
        using var unitOfWork = _unitOfWorkFactory.Create();
        var folder = unitOfWork.FolderRepository.GetById(query.FolderId);
        unitOfWork.Commit();

        if (folder == null)
            return Result.Failure(Error.NotFound);

        var dto = new FolderDto(folder.Id, folder.Name, folder.ParentFolderId);
        return Result.Success(dto);
    }
}
