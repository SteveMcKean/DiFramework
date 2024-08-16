namespace Consumer.ConsoleApp;

public class IdGenerator : IIdGenerator
{
    private readonly IConsoleWriter consoleWriter;
    public Guid Id { get; } = Guid.NewGuid();
    
    public IdGenerator(IConsoleWriter consoleWriter)
    {
        this.consoleWriter = consoleWriter;
    }
    
    public void PrintId()
    {
        consoleWriter.WriteLine(Id.ToString());
    }
}