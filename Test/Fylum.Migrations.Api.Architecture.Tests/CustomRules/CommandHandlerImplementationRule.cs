using Mono.Cecil;
using NetArchTest.Rules;

namespace Fylum.Migrations.Api.Architecture.Tests.CustomRules;

internal class CommandHandlerImplementationRule : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
    {
        if (type.IsInterface)
            return false;

        bool implementsAny = type.Interfaces
            .Select(i => i.InterfaceType as GenericInstanceType)
            .Any(IsCommandHandlerInterface);
        return implementsAny;
    }

    private static bool IsCommandHandlerInterface(GenericInstanceType? gi)
    {
        if (gi == null)
            return false;
        return gi.Name.StartsWith(GenericNames.CommandHandlerTypeName)
            || gi.Name.StartsWith(GenericNames.ResultTypedCommandHandlerTypeName);
    }
}
