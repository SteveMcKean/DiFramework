namespace Consumer.ConsoleApp;

public interface ILoggerAdapter<TType>
{
    void LogInformation(string template, params object[] args);    
}