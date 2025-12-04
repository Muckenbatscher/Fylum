using Dapper;
using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain;
using Fylum.Users.Domain.Groups;

namespace Fylum.Users.Postgres;

public class UserWithGroupsRepository : IUserWithGroupsRepository
{
    private readonly IUnitOfWorkTransactionFactory _transactionFactory;

    public UserWithGroupsRepository(IUnitOfWorkTransactionFactory transactionFactory)
    {
        _transactionFactory = transactionFactory;
    }

    public UserWithGroups? GetByUserId(Guid userId)
    {
        var queryModels = GetQueryModelsByUserId(userId);
        var usersWithGroups = GetFromQueryModels(queryModels);
        return usersWithGroups.FirstOrDefault();
    }


    private IEnumerable<UserWithGroupsQueryModel> GetQueryModelsByUserId(Guid id)
    {
        var param = new { id };
        string sql = @$"SELECT u.id as {nameof(UserWithGroupsQueryModel.UserId)},  
                                   u.username as {nameof(UserWithGroupsQueryModel.Username)}, 
                                   u.is_active as {nameof(UserWithGroupsQueryModel.IsActive)},
                                   g.id as {nameof(UserWithGroupsQueryModel.UserGroupId)},
                                   g.name as {nameof(UserWithGroupsQueryModel.UserGroupName)}
	                        FROM users u
                            LEFT JOIN user_group_members gm
                                ON gm.user_id = u.id
                            LEFT JOIN user_groups g
                                ON g.id = gm.group_id
                            WHERE u.id = @{nameof(param.id)}";
        var transaction = _transactionFactory.GetTransaction();
        var connection = transaction.Connection;
        return connection.Query<UserWithGroupsQueryModel>(sql, param);
    }

    private IEnumerable<UserWithGroups> GetFromQueryModels(IEnumerable<UserWithGroupsQueryModel> queryModels)
    {
        var distinctUserIds = queryModels.Select(m => m.UserId).Distinct();
        var users = new List<UserWithGroups>();
        foreach (var userId in distinctUserIds)
        {
            var matchingModels = queryModels.Where(m => m.UserId == userId);
            var firstUser = matchingModels.First();
            var user = User.Create(userId, firstUser.Username, firstUser.IsActive);
            var groups = matchingModels.Where(m => m.UserGroupId.HasValue && m.UserGroupName != null)
                .Select(m => UserGroup.Create(m.UserGroupId!.Value, m.UserGroupName!));
            var userWithGroups = UserWithGroups.Create(user, groups);
            users.Add(userWithGroups);
        }
        return users;
    }
}