namespace Fylum.Domain.Files;

public class File : IdentifiableEntity<Guid>
{
    public File(Guid id) : base(id)
    {
    }
    public string Name { get; set; } = string.Empty;
    public Guid ParentFolderId { get; set; }
}