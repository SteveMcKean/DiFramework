using MultiFunction.ConsoleApp;

public class ConsoleWriter: IConsoleWriter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}