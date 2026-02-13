using System.Text.Json.Serialization;

namespace Fylum.Folders.SharedModels.CreateFolder;

public record CreateFolderRequest(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("parent_folder_id")] Guid ParentFolderId);
