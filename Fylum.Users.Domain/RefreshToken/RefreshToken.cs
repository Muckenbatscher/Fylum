using Fylum.Domain;

namespace Fylum.Users.Domain.RefreshToken;

public class RefreshToken : IdentifiableEntity<Guid>
{
    public Guid UserId { get; }
    public DateTimeOffset IssuedAt { get; private set; }
    public DateTimeOffset ExpiredAt { get; private set; }

    public bool IsValid
        => DateTimeOffset.UtcNow < ExpiredAt && DateTimeOffset.UtcNow > IssuedAt;

    private RefreshToken(Guid id, Guid userId, DateTimeOffset issuedAt, DateTimeOffset expiredAt) : base(id)
    {
        UserId = userId;
        IssuedAt = issuedAt;
        ExpiredAt = expiredAt;
    }

    public static RefreshToken IssueNew(Guid userId, TimeSpan validFor)
    {
        var id = Guid.NewGuid();
        var issuedAt = DateTimeOffset.UtcNow;
        var expiredAt = issuedAt.Add(validFor);
        return new RefreshToken(id, userId, issuedAt, expiredAt);
    }

    public static RefreshToken Create(Guid id, Guid userId, DateTimeOffset issuedAt, DateTimeOffset expiredAt)
    {
        return new RefreshToken(id, userId, issuedAt, expiredAt);
    }

    public void Invalidate()
    {
        ExpiredAt = DateTimeOffset.UtcNow;
    }
}
