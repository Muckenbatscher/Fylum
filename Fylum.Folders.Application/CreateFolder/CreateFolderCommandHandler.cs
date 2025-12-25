using Fylum.Application;
using Fylum.Folders.Domain;

namespace Fylum.Folders.Application.CreateFolder;

public class CreateFolderCommandHandler : ICommandHandler<CreateFolderCommand, CreateFolderResult>
{
    private readonly IFolderUnitOfWorkFactory _unitOfWorkFactory;

    public CreateFolderCommandHandler(IFolderUnitOfWorkFactory unitOfWorkFactory)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public Result<CreateFolderResult> Handle(CreateFolderCommand command)
    {
        using var unitOfWork = _unitOfWorkFactory.Create();
        var folderRepository = unitOfWork.FolderRepository;
        var parentFolder = folderRepository.GetById(command.ParentFolderId);
        if (parentFolder == null)
            return Result.Failure<CreateFolderResult>(Error.NotFound);

        var otherChildFolders = folderRepository.GetChildFolders(parentFolder.Id);
        if (otherChildFolders.Any(folder => folder.Name.Equals(command.Name, StringComparison.OrdinalIgnoreCase)))
            return Result.Failure<CreateFolderResult>(Error.Conflict);

        var newFolder = Folder.CreateNew(command.ParentFolderId, command.Name);

        folderRepository.Add(newFolder);
        unitOfWork.Commit();

        var result = new CreateFolderResult
        (
            Id: newFolder.Id,
            Name: newFolder.Name,
            ParentFolderId: newFolder.ParentFolderId
        );
        return Result.Success(result);
    }
}
