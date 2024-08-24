using MultiFunction.ConsoleApp.Handlers;

public class Application
{
    private readonly IConsoleWriter consoleWriter;
    private readonly HandlerOrchestrator handlerOrchestrator;
    public Application(IConsoleWriter consoleWriter, HandlerOrchestrator handlerOrchestrator)
    {
        this.consoleWriter = consoleWriter;
        this.handlerOrchestrator = handlerOrchestrator;
    }

    public async Task RunAsync(string[] args)
    {
        var command = args[0];
        
        var handler = handlerOrchestrator.GetHandlerForCommandName(command);
        if(handler is null)
        {
            consoleWriter.WriteLine($"No handler found for the command {command}.");
            return;
        }
        
        await handler.HandleAsync();
    }
}