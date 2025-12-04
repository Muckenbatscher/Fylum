namespace Fylum.Domain.Tags;

public class Tag : IdentifiableEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
}