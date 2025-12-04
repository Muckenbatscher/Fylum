namespace Fylum.Shared.Files;

public class FileResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid ParentFolderId { get; set; }
    public Guid LatestRevisionId { get; set; }
}