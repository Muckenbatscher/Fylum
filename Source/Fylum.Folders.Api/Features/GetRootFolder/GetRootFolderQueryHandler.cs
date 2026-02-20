using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Core.Domain;
using Fylum.Folders.Api.Common.Domain;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.GetRootFolder;

public class GetRootFolderQueryHandler : IGetRootFolderQueryHandler
{
    private const string RootFolderId = "120A803B-2924-4519-811C-1E3ABA90FD52";

    private readonly IUnitOfWorkFactory<FolderUnitOfWork> _unitOfWorkFactory;
    private readonly IMapper<Folder, FolderDto> _mapper;

    public GetRootFolderQueryHandler(
        IUnitOfWorkFactory<FolderUnitOfWork> unitOfWorkFactory,
        IMapper<Folder, FolderDto> mapper)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _mapper = mapper;
    }

    public Result<FolderDto> Handle(GetRootFolderQuery query)
    {
        using var unitOfWork = _unitOfWorkFactory.Create();
        var rootFolderGuid = Guid.Parse(RootFolderId);
        var rootFolder = unitOfWork.FolderRepository.GetById(rootFolderGuid);
        unitOfWork.Commit();

        if (rootFolder == null)
            return Result.Failure(Error.NotFound);

        var dto = _mapper.Map(rootFolder);
        return Result.Success(dto);
    }
}
