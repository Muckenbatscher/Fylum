using System.Text.Json.Serialization;

namespace Fylum.Folders.SharedModels.GetFolderById;

public record GetFolderByResponse(
    [property: JsonPropertyName("folder")] FolderDto Folder);
