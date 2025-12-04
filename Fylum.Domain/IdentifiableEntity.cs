namespace Fylum.Domain;

public abstract class IdentifiableEntity<Key>
    where Key : struct
{
    public Key Id { get; init; }

    public override bool Equals(object? obj)
    {
        return obj is IdentifiableEntity<Key> entity &&
               EqualityComparer<Key>.Default.Equals(Id, entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}