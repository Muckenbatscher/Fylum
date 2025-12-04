namespace Fylum.Domain.Tags;

public class FileTag : IdentifiableEntity<Guid>
{
    public Guid FileId { get; set; }
    public Guid TagId { get; set; }
}