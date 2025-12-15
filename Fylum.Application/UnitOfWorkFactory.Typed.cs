using Fylum.Domain.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fylum.Application;

public abstract class UnitOfWorkFactory<T> : UnitOfWorkFactory
    where T : UnitOfWork
{
    public UnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory)
        : base(serviceScopeFactory)
    {
    }

    public virtual T Create()
    {
        var constructors = typeof(T).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        var constructor = constructors.Length == 1
            ? constructors[0]
            : throw new InvalidOperationException($"Type {typeof(T).FullName} must have exactly one public constructor.");

        CreateScope();

        var parameterTypes = constructor.GetParameters().Select(p => p.ParameterType).ToArray();
        var arguments = parameterTypes.Select(GetService).ToArray();

        var unitOfWok = (T)constructor.Invoke(arguments)!;
        return unitOfWok;
    }

    private object GetService(Type type)
    {
        if (type == typeof(IUnitOfWorkTransactionFactory))
            return GetTransactionFactory();

        var methodFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        var method = typeof(UnitOfWorkFactory).GetMethod(nameof(GetScopedService), methodFlags);
        var genericMethod = method!.MakeGenericMethod(type);
        return genericMethod.Invoke(this, [])!;
    }
}
