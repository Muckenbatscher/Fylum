using Mono.Cecil;
using NetArchTest.Rules;

namespace Fylum.ArchitectureTest.Common.CustomRules;

internal class QueryHandlerNameMatchesQueryRule : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
    {
        var handlerInterface = type.Interfaces
            .Select(i => i.InterfaceType as GenericInstanceType)
            .FirstOrDefault(IsQueryHandlerInterface);

        if (handlerInterface == null)
            return true; // Not a handler, skip

        // first generic argument is the query type
        var queryType = handlerInterface.GenericArguments.FirstOrDefault();
        if (queryType == null)
            return false;

        // HandlerName == QueryName + "Handler"
        var expectedHandlerName = $"{queryType.Name}Handler";
        return type.Name.Equals(expectedHandlerName);
    }

    private static bool IsQueryHandlerInterface(GenericInstanceType? gi)
    {
        if (gi == null)
            return false;
        return gi.Name.StartsWith(GenericNames.QueryHandlerTypeName);
    }
}
