using Fylum.Folders.Api.Shared;

namespace Fylum.Client.Folders;

public interface IFolderClient
{
    Task<GetFolderResponse> GetRootFolderAsync();
    Task<GetFolderResponse> GetRootFolderAsync(CancellationToken cancellationToken);

    Task<GetFolderResponse> GetFolderByIdAsync(Guid folderId);
    Task<GetFolderResponse> GetFolderByIdAsync(Guid folderId, CancellationToken cancellationToken);

    Task<GetFoldersResponse> GetChildFoldersAsync(Guid parentFolderId);
    Task<GetFoldersResponse> GetChildFoldersAsync(Guid parentFolderId, CancellationToken cancellationToken);

    Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest createFolderRequest);
    Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest createFolderRequest, CancellationToken cancellationToken);
}
