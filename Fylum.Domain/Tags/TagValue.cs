
namespace Fylum.Domain.Tags;

public abstract class TagValue<T> : Tag
    where T : notnull
{
    protected TagValue(Guid id) : base(id)
    {
    }

    public T Value { get; set; } = default!;
}