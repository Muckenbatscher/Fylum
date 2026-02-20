using Mono.Cecil;
using NetArchTest.Rules;

namespace Fylum.ArchitectureTest.Common.CustomRules;

internal class CommandHandlerNameMatchesCommandRule : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
    {
        var handlerInterface = type.Interfaces
            .Select(i => i.InterfaceType as GenericInstanceType)
            .FirstOrDefault(IsCommandHandlerInterface);

        if (handlerInterface == null)
            return true; // Not a handler, skip

        // first generic argument is the command type
        var commandType = handlerInterface.GenericArguments.FirstOrDefault();
        if (commandType == null)
            return false;

        // HandlerName == CommandName + "Handler"
        var expectedHandlerName = $"{commandType.Name}Handler";
        return type.Name.Equals(expectedHandlerName);
    }

    private static bool IsCommandHandlerInterface(GenericInstanceType? gi)
    {
        if (gi == null)
            return false;
        return gi.Name.StartsWith(GenericNames.CommandHandlerTypeName)
            || gi.Name.StartsWith(GenericNames.ResultTypedCommandHandlerTypeName);
    }
}
