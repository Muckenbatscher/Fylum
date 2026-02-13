using Fylum.Core.Application.Command;

namespace Fylum.Users.Api.Features.Login;

public interface IUserLoginCommandHandler : ICommandHandler<UserLoginCommand, UserLoginResult>
{
}
