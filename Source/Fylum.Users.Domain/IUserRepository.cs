namespace Fylum.Users.Domain;

public interface IUserRepository
{
    User? GetById(Guid id);
    User? GetByUsername(string username);
}