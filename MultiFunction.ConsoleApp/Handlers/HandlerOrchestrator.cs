using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MultiFunction.ConsoleApp.Handlers;

public class HandlerOrchestrator
{
    private readonly Dictionary<string, Type> handlerTypes = new();
    
    private readonly IServiceScopeFactory serviceScopeFactory;

    public HandlerOrchestrator(IServiceScopeFactory serviceScopeFactory)
    {
        this.serviceScopeFactory = serviceScopeFactory;
        RegisterCommandHandlers();
    }

    public IHandler? GetHandlerForCommandName(string command)
    {
        var handlerType = handlerTypes.GetValueOrDefault(command);
        
        if(handlerType is null)
        {
            return null;
        }
        
        using var scope = serviceScopeFactory.CreateScope();
        var handler = (IHandler)scope.ServiceProvider.GetRequiredService(handlerType);
        
        return handler;
    }
    
    private void RegisterCommandHandlers()
    {
        var handlerTypes = HandlerExtensions.GetHandlerTypesForAssembly(typeof(IHandler).Assembly);

        foreach(var handlerType in handlerTypes)
        {
            var commandName = handlerType.GetCustomAttribute<CommandNameAttribute>()!.CommandName;
            this.handlerTypes.Add(commandName, handlerType);
        }
    }

 
}