using Fylum.Client.HttpMessaging;
using Fylum.Folders.Api.Shared;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Fylum.Client.Folders;

public class FolderClient : IFolderClient
{
    private readonly HttpClient _httpClient;

    public FolderClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetFolderResponse> GetRootFolderAsync() => await GetRootFolderAsync(CancellationToken.None);
    public async Task<GetFolderResponse> GetRootFolderAsync(CancellationToken cancellationToken)
    {
        var route = $"{EndpointRoutes.FolderBaseRoute}/{EndpointRoutes.RootFolderRoute}";
        var response = await _httpClient.GetAsync(route, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Could not get root folder");
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<GetFolderResponse>(responseContent, JsonSerializerOptions.Web)
            ?? throw new JsonParsingException<GetFolderResponse>(responseContent);
        return result;
    }

    public async Task<GetFolderResponse> GetFolderByIdAsync(Guid folderId) => await GetFolderByIdAsync(folderId, CancellationToken.None);
    public async Task<GetFolderResponse> GetFolderByIdAsync(Guid folderId, CancellationToken cancellationToken)
    {
        var route = $"{EndpointRoutes.FolderBaseRoute}/{folderId}";
        var response = await _httpClient.GetAsync(route, cancellationToken);
        if (response.StatusCode == HttpStatusCode.NotFound)
            throw new Exception($"Folder with Id {folderId} was not found");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Could not get folder");
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<GetFolderResponse>(responseContent, JsonSerializerOptions.Web)
            ?? throw new JsonParsingException<GetFolderResponse>(responseContent);
        return result;
    }

    public async Task<GetFoldersResponse> GetChildFoldersAsync(Guid parentFolderId) => await GetChildFoldersAsync(parentFolderId, CancellationToken.None);
    public async Task<GetFoldersResponse> GetChildFoldersAsync(Guid parentFolderId, CancellationToken cancellationToken)
    {
        var route = $"{EndpointRoutes.FolderBaseRoute}/{parentFolderId}/{EndpointRoutes.ChildFoldersRoute}";
        var response = await _httpClient.GetAsync(route, cancellationToken);
        if (response.StatusCode == HttpStatusCode.NotFound)
            throw new Exception($"Folder with Id {parentFolderId} was not found");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Could not get child folders");
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<GetFoldersResponse>(responseContent, JsonSerializerOptions.Web)
            ?? throw new JsonParsingException<GetFoldersResponse>(responseContent);
        return result;
    }

    public async Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest createFolderRequest) => await CreateFolderAsync(createFolderRequest, CancellationToken.None);
    public async Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest createFolderRequest, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            EndpointRoutes.FolderBaseRoute, createFolderRequest, cancellationToken);
        if (response.StatusCode == HttpStatusCode.NotFound)
            throw new Exception($"Folder with Id {createFolderRequest.ParentFolderId} was not found");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Could not create folder");
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<CreateFolderResponse>(responseContent, JsonSerializerOptions.Web)
            ?? throw new JsonParsingException<CreateFolderResponse>(responseContent);
        return result;
    }
}
