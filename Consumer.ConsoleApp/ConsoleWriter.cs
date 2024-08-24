namespace Consumer.ConsoleApp;

public class ConsoleWriter: IConsoleWriter
{
    private ILoggerAdapter<ConsoleWriter> loggerAdapter;
    public ConsoleWriter(ILoggerAdapter<ConsoleWriter> loggerAdapter)
    {
        this.loggerAdapter = loggerAdapter;
        
    }
    public void WriteLine(string text)
    {
        loggerAdapter.LogInformation(text);
        Console.WriteLine(text);
    }
}