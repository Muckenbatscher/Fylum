using System.Text.Json.Serialization;

namespace Fylum.Folders.SharedModels.GetRootFolder;

public record GetRootFolderResponse(
    [property: JsonPropertyName("root_folder")] FolderDto RootFolder);
