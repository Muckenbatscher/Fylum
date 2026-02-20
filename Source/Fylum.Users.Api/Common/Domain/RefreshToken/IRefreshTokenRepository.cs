namespace Fylum.Users.Api.Common.Domain.RefreshToken;

public interface IRefreshTokenRepository
{
    public RefreshToken? GetById(Guid id);
    public void Add(RefreshToken refreshToken);
    public void Update(RefreshToken refreshToken);
}