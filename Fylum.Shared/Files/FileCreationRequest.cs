namespace Fylum.Shared.Files;

public class FileCreationRequest
{
    public string Name { get; set; } = string.Empty;
    public Guid ParentFolderId { get; set; }
}