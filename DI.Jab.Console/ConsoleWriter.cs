namespace DI.Jab.Console;

public class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string message)
    {
        System.Console.WriteLine(message);
    }
}