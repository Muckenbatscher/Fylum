namespace Fylum.Domain.Revisions;

public class Revision : IdentifiableEntity<Guid>
{
    public Revision(Guid id) : base(id)
    {
    }

    public Guid FileId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ChangeDescription { get; set; } = string.Empty;
    public DateTime CreationTimestampUtc { get; set; }
}