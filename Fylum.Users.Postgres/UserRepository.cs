using Dapper;
using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Postgres
{
    internal class UserRepository : IUserRepository
    {
        private readonly IUnitOfWorkTransactionFactory _transactionFactory;

        public UserRepository(IUnitOfWorkTransactionFactory transactionFactory)
        {
            _transactionFactory = transactionFactory;
        }

        public User? GetById(Guid id)
        {
            var queryModel = GetQueryModelById(id);
            if (queryModel == null)
                return null;

            return User.Create(queryModel.Id, queryModel.Username, queryModel.IsActive);
        }
        public User? GetByUsername(string username)
        {
            var queryModel = GetQueryModelByUsername(username);
            if (queryModel == null)
                return null;

            return User.Create(queryModel.Id, queryModel.Username, queryModel.IsActive);
        }

        private UserQueryModel? GetQueryModelById(Guid id)
        {
            var param = new { id };
            string sql = @$"SELECT id as {nameof(UserQueryModel.Id)},  
                                   username as {nameof(UserQueryModel.Username)}, 
                                   is_active as {nameof(UserQueryModel.IsActive)}
	                        FROM users
                            WHERE id = @{nameof(param.id)}";
            var transaction = _transactionFactory.GetTransaction();
            var connection = transaction.Connection;
            return connection.QuerySingleOrDefault<UserQueryModel>(sql, param);
        }
        private UserQueryModel? GetQueryModelByUsername(string username)
        {
            var param = new { username };
            string sql = @$"SELECT id as {nameof(UserQueryModel.Id)},  
                                   username as {nameof(UserQueryModel.Username)}, 
                                   is_active as {nameof(UserQueryModel.IsActive)}
	                        FROM users
                            WHERE username = @{nameof(param.username)}";
            var transaction = _transactionFactory.GetTransaction();
            var connection = transaction.Connection;
            return connection.QuerySingleOrDefault<UserQueryModel>(sql, param);
        }
    }
}
