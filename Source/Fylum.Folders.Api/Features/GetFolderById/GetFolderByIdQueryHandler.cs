using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Core.Domain;
using Fylum.Folders.Api.Common.Domain;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.GetFolderById;

public class GetFolderByIdQueryHandler : IGetFolderByIdQueryHandler
{
    private readonly IUnitOfWorkFactory<FolderUnitOfWork> _unitOfWorkFactory;
    private readonly IMapper<Folder, FolderDto> _mapper;

    public GetFolderByIdQueryHandler(
        IUnitOfWorkFactory<FolderUnitOfWork> unitOfWorkFactory,
        IMapper<Folder, FolderDto> mapper)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _mapper = mapper;
    }

    public Result<FolderDto> Handle(GetFolderByIdQuery query)
    {
        using var unitOfWork = _unitOfWorkFactory.Create();
        var folder = unitOfWork.FolderRepository.GetById(query.FolderId);
        unitOfWork.Commit();

        if (folder == null)
            return Result.Failure(Error.NotFound);

        var dto = _mapper.Map(folder);
        return Result.Success(dto);
    }
}
