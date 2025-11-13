using Dapper;
using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Postgres
{
    public class UserWithPasswordRepository : IUserWithPasswordRepository
    {
        private readonly IUnitOfWorkTransactionFactory _transactionFactory;

        public UserWithPasswordRepository(IUnitOfWorkTransactionFactory transactionFactory)
        {
            _transactionFactory = transactionFactory;
        }

        public void Create(UserWithPasswordLogin userWithPasswordLogin)
        {
            InsertUser(
                userWithPasswordLogin.User.Id,
                userWithPasswordLogin.User.Username,
                userWithPasswordLogin.User.IsActive);
            InsertUserPasswordLogin(
                userWithPasswordLogin.User.Id,
                userWithPasswordLogin.Login.PasswordHash,
                userWithPasswordLogin.Login.Salt);
        }

        public UserWithPasswordLogin? GetByUsername(string username)
        {
            var queryModel = GetQueryModelByUsername(username);
            if (queryModel == null)
                return null;
            bool queryModelPasswordFilled = queryModel.PasswordHash != null && queryModel.PasswordSalt != null;
            if (!queryModelPasswordFilled)
                return null;

            return UserWithPasswordLogin.Create(
                queryModel.UserId,
                queryModel.Username,
                queryModel.UserIsActive,
                queryModel.PasswordHash!,
                queryModel.PasswordSalt!);
        }

        private UserWithPasswordQueryModel? GetQueryModelByUsername(string username)
        {
            var param = new { username };
            string sql = @$"SELECT u.id as {nameof(UserWithPasswordQueryModel.UserId)},  
                                   u.username as {nameof(UserWithPasswordQueryModel.Username)}, 
                                   u.is_active as {nameof(UserWithPasswordQueryModel.UserIsActive)},
                                   ul.password_hash as {nameof(UserWithPasswordQueryModel.PasswordHash)},
                                   ul.password_salt as {nameof(UserWithPasswordQueryModel.PasswordSalt)}
	                        FROM users u
                            LEFT JOIN user_password_logins ul
                                ON u.id = ul.user_id
                            WHERE u.username = @{nameof(param.username)}";
            var transaction = _transactionFactory.GetTransaction();
            var connection = transaction.Connection;
            return connection.QuerySingleOrDefault<UserWithPasswordQueryModel>(sql, param, transaction.Transaction);
        }

        private void InsertUserPasswordLogin(Guid userId, string passwordHash, string passwordSalt)
        {
            var param = new
            {
                userId,
                passwordHash,
                passwordSalt
            };
            string sql = @$"INSERT INTO user_password_logins 
                            (user_id, password_hash, password_salt)
                            VALUES (@{nameof(param.userId)}, @{nameof(param.passwordHash)}, @{nameof(param.passwordSalt)})";
            var transaction = _transactionFactory.GetTransaction();
            var connection = transaction.Connection;
            connection.Execute(sql, param, transaction.Transaction);
        }
        private void InsertUser(Guid id, string username, bool isActive)
        {
            var param = new
            {
                id,
                username,
                isActive
            };
            string sql = @$"INSERT INTO users 
                            (id, username, is_active)
                            VALUES (@{nameof(param.id)}, @{nameof(param.username)}, @{nameof(param.isActive)})";
            var transaction = _transactionFactory.GetTransaction();
            var connection = transaction.Connection;
            connection.Execute(sql, param, transaction.Transaction);
        }
    }
}
