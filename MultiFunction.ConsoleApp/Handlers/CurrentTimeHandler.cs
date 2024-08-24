namespace MultiFunction.ConsoleApp.Handlers;

[CommandName("time")]
public class CurrentTimeHandler : IHandler
{
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly IConsoleWriter consoleWriter;
    public CurrentTimeHandler(IDateTimeProvider dateTimeProvider, IConsoleWriter consoleWriter)
    {
        this.dateTimeProvider = dateTimeProvider;
        this.consoleWriter = consoleWriter;
    }
    public Task HandleAsync()
    {
        consoleWriter.WriteLine($"Current time: {dateTimeProvider.Now:0}");
        return Task.CompletedTask;
    }
}