using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Core.Domain;
using Fylum.Folders.Api.Common.Domain;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.CreateFolder;

public class CreateFolderCommandHandler : ICreateFolderCommandHandler
{
    private readonly IUnitOfWorkFactory<FolderUnitOfWork> _unitOfWorkFactory;
    private readonly IMapper<Folder, FolderDto> _mapper;

    public CreateFolderCommandHandler(IUnitOfWorkFactory<FolderUnitOfWork> unitOfWorkFactory,
        IMapper<Folder, FolderDto> mapper)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _mapper = mapper;
    }

    public Result<FolderDto> Handle(CreateFolderCommand command)
    {
        using var unitOfWork = _unitOfWorkFactory.Create();
        var folderRepository = unitOfWork.FolderRepository;
        var parentFolder = folderRepository.GetById(command.ParentFolderId);
        if (parentFolder == null)
            return Result.Failure<FolderDto>(Error.NotFound);

        var otherChildFolders = folderRepository.GetChildFolders(parentFolder.Id);
        if (otherChildFolders.Any(folder => folder.Name.Equals(command.Name, StringComparison.OrdinalIgnoreCase)))
            return Result.Failure<FolderDto>(Error.Conflict);

        var newFolder = Folder.CreateNew(command.ParentFolderId, command.Name);

        folderRepository.Add(newFolder);
        unitOfWork.Commit();

        var result = _mapper.Map(newFolder);
        return Result.Success(result);
    }
}
