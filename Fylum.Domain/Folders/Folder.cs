namespace Fylum.Domain.Folders;

public class Folder : IdentifiableEntity<Guid>
{
    public Guid ParentFolderId { get; set; }
    public string Name { get; set; } = string.Empty;
}