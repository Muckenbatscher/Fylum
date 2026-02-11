namespace Fylum.Users.Api.Common.Domain;

public interface IUserRepository
{
    User? GetById(Guid id);
    User? GetByUsername(string username);
}