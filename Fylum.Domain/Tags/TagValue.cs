namespace Fylum.Domain.Tags;

public abstract class TagValue<T> : Tag
    where T : notnull
{
    public T Value { get; set; } = default!;
}