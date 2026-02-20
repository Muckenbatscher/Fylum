using System.Text.Json.Serialization;

namespace Fylum.Folders.SharedModels.GetChildFolders;

public record GetChildFoldersResponse(
    [property: JsonPropertyName("folders")] IList<FolderDto> Folders);