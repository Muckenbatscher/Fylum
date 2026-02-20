using Fylum.Core.Application.Command;
using Fylum.Core.Application.Query;

namespace Fylum.ArchitectureTest.Common.CustomRules;

internal class GenericNames
{
    public static readonly string CommandHandlerTypeName = $"{nameof(ICommandHandler<>)}`1";
    public static readonly string ResultTypedCommandHandlerTypeName = $"{nameof(ICommandHandler<,>)}`2";

    public static readonly string QueryHandlerTypeName = $"{nameof(IQueryHandler<,>)}`2";
}
