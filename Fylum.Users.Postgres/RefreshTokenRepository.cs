using Dapper;
using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain.RefreshToken;

namespace Fylum.Users.Postgres;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly IUnitOfWorkTransactionFactory _transactionFactory;

    public RefreshTokenRepository(IUnitOfWorkTransactionFactory transactionFactory)
    {
        _transactionFactory = transactionFactory;
    }

    public RefreshToken? GetById(Guid id)
    {
        var param = new { Id = id };
        var query = $@"SELECT id as {nameof(RefreshTokenQueryModel.Id)},
                              user_id as {nameof(RefreshTokenQueryModel.UserId)},
                              issued_at as {nameof(RefreshTokenQueryModel.IssuedAt)},
                              expired_at as {nameof(RefreshTokenQueryModel.ExpiresAt)}
                       FROM user_refresh_keys
                       WHERE id = @{nameof(param.Id)};";
        var transaction = _transactionFactory.GetTransaction();
        var connection = transaction.Connection;
        var result = connection.QuerySingleOrDefault<RefreshTokenQueryModel>(
            query, param, transaction.Transaction);
        if (result == null)
            return null;

        return RefreshToken.Create(result.Id, result.UserId, result.IssuedAt, result.ExpiresAt);
    }
    public void Add(RefreshToken refreshToken)
    {
        var param = new
        {
            refreshToken.Id,
            refreshToken.UserId,
            refreshToken.IssuedAt,
            refreshToken.ExpiresAt
        };
        var command = $@"INSERT INTO user_refresh_keys 
                         (id, user_id, issued_at, expired_at)
                         VALUES (@{nameof(param.Id)}, 
                                 @{nameof(param.UserId)}, 
                                 @{nameof(param.IssuedAt)}, 
                                 @{nameof(param.ExpiresAt)});";
        var transaction = _transactionFactory.GetTransaction();
        var connection = transaction.Connection;
        connection.Execute(command, param, transaction.Transaction);
    }
    public void Update(RefreshToken refreshToken)
    {
        var param = new
        {
            refreshToken.Id,
            refreshToken.IssuedAt,
            refreshToken.ExpiresAt
        };
        var command = $@"UPDATE user_refresh_keys
                         SET issued_at = @{nameof(param.IssuedAt)},
                             expired_at = @{nameof(param.ExpiresAt)}
                         WHERE id = @{nameof(param.Id)};";
        var transaction = _transactionFactory.GetTransaction();
        var connection = transaction.Connection;
        connection.Execute(command, param, transaction.Transaction);
    }
}
