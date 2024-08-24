using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MultiFunction.ConsoleApp.Handlers;

namespace MultiFunction.ConsoleApp;

public static class HandlerExtensions
{
    public static void AddCommandHandlers(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = GetHandlerTypesForAssembly(assembly);
        foreach (var handlerType in handlerTypes)
        {
            services.TryAddTransient(handlerType);
        }
    }
    
    public static IEnumerable<TypeInfo> GetHandlerTypesForAssembly(Assembly assembly)
    {
        var handlerTypes = assembly.DefinedTypes
            .Where(x => !x.IsInterface && !x.IsAbstract && typeof(IHandler).IsAssignableFrom(x));
        
        return handlerTypes;
    }
}