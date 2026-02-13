using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Core.Domain;
using Fylum.Folders.Api.Common.Domain;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.GetChildFolders;

public class GetChildFoldersQueryHandler : IGetChildFoldersQueryHandler
{
    private readonly IUnitOfWorkFactory<FolderUnitOfWork> _unitOfWorkFactory;
    private readonly IMapper<IEnumerable<Folder>, IEnumerable<FolderDto>> _mapper;

    public GetChildFoldersQueryHandler(
        IUnitOfWorkFactory<FolderUnitOfWork> unitOfWorkFactory,
        IMapper<IEnumerable<Folder>, IEnumerable<FolderDto>> mapper)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _mapper = mapper;
    }

    public Result<IList<FolderDto>> Handle(GetChildFoldersQuery query)
    {
        using var unitOfWork = _unitOfWorkFactory.Create();
        var folder = unitOfWork.FolderRepository.GetById(query.ParentFolderId);

        if (folder == null)
            return Result.Failure(Error.NotFound);

        var childFolders = unitOfWork.FolderRepository.GetChildFolders(query.ParentFolderId);

        var dtos = _mapper.Map(childFolders).ToList();
        return Result.Success<IList<FolderDto>>(dtos);
    }
}
