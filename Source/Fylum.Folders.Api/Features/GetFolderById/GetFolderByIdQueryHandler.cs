using Fylum.Core.Application.Query;
using Fylum.Core.Application.Results;
using Fylum.Core.Domain;
using Fylum.Folders.Api.Common.Application;
using Fylum.Folders.Api.Common.Domain;

namespace Fylum.Folders.Api.Features.GetFolderById;

public class GetFolderByIdQueryHandler : IQueryHandler<GetFolderByIdQuery, FolderDto>
{
    private readonly IUnitOfWorkFactory<FolderUnitOfWork> _unitOfWorkFactory;

    public GetFolderByIdQueryHandler(IUnitOfWorkFactory<FolderUnitOfWork> unitOfWorkFactory)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public Result<FolderDto> Handle(GetFolderByIdQuery query)
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
