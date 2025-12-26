using Fylum.Application;
using Fylum.Domain.UnitOfWork;
using Fylum.Users.Domain.Logout;

namespace Fylum.Users.Application.Logout;

public class LogoutCommandHandler : ILogoutCommandHandler
{
    private readonly IUnitOfWorkFactory<LogoutUnitOfWork> _unitOfWorkFactory;

    public LogoutCommandHandler(IUnitOfWorkFactory<LogoutUnitOfWork> unitOfWorkFactory)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public Result Handle(LogoutCommand command)
    {
        using var unitOfWork = _unitOfWorkFactory.Create();

        var refreshTokenRepo = unitOfWork.RefreshTokenRepository;
        var token = refreshTokenRepo.GetById(command.RefreshId);
        if (token == null)
            return Result.Failure(Error.NotFound);
        if (!token.IsValid)
            return Result.Failure(Error.Validation);
        if (token.UserId != command.UserId)
            return Result.Failure(Error.Unauthorized);

        token.Invalidate();
        refreshTokenRepo.Update(token);
        unitOfWork.Commit();

        return Result.Success();
    }
}
