namespace Fylum.Domain.Tags;

public class Tag : IdentifiableEntity<Guid>
{
    public Tag(Guid id) : base(id)
    {
    }

    public string Name { get; set; } = string.Empty;
}