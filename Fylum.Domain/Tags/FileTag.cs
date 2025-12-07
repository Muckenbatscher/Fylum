namespace Fylum.Domain.Tags;

public class FileTag : IdentifiableEntity<Guid>
{
    public FileTag(Guid id) : base(id)
    {
    }

    public Guid FileId { get; set; }
    public Guid TagId { get; set; }
}