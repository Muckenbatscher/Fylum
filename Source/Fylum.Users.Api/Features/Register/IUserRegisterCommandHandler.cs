using Fylum.Core.Application.Command;

namespace Fylum.Users.Api.Features.Register;

public interface IUserRegisterCommandHandler : ICommandHandler<UserRegisterCommand, UserRegisterResult>
{
}
