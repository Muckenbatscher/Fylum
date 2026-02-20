using Fylum.Folders.SharedModels.CreateFolder;
using Fylum.Folders.SharedModels.GetChildFolders;
using Fylum.Folders.SharedModels.GetFolderById;
using Fylum.Folders.SharedModels.GetRootFolder;

namespace Fylum.Client.Folders;

public interface IFolderClient
{
    Task<GetRootFolderResponse> GetRootFolderAsync();
    Task<GetRootFolderResponse> GetRootFolderAsync(CancellationToken cancellationToken);

    Task<GetFolderByResponse> GetFolderByIdAsync(Guid folderId);
    Task<GetFolderByResponse> GetFolderByIdAsync(Guid folderId, CancellationToken cancellationToken);

    Task<GetChildFoldersResponse> GetChildFoldersAsync(Guid parentFolderId);
    Task<GetChildFoldersResponse> GetChildFoldersAsync(Guid parentFolderId, CancellationToken cancellationToken);

    Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest createFolderRequest);
    Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest createFolderRequest, CancellationToken cancellationToken);
}
