namespace Fylum.Users.Domain.Groups;

public interface IUserWithGroupsRepository
{
    UserWithGroups? GetByUserId(Guid userId);
}