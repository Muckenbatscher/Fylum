using System.Text.Json.Serialization;

namespace Fylum.Folders.SharedModels;

public record FolderDto(
    [property: JsonPropertyName("id")] Guid Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("parent_folder_id")] Guid ParentFolderId);
