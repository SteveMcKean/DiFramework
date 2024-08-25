using Microsoft.Extensions.Logging;

namespace Consumer.ConsoleApp;

public interface ILoggerAdapter<TType>
{
    void LogInformation(string template, params object[] args);
    void LogInformation(LogLevel logLevel, string template, object[] args);
    IDisposable TimedOperation(string template, object[] args);
}