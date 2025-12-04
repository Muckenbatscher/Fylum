namespace Fylum.Domain.Files;

public class File : IdentifiableEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public Guid ParentFolderId { get; set; }
}