using System.Text.Json.Serialization;

namespace Fylum.Folders.SharedModels.CreateFolder;

public record CreateFolderResponse(
    [property: JsonPropertyName("created_folder")] FolderDto CreatedFolder);
