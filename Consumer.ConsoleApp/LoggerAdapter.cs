using Microsoft.Extensions.Logging;

namespace Consumer.ConsoleApp;

public class LoggerAdapter<TType> : ILoggerAdapter<TType>
{
    private readonly ILogger<LoggerAdapter<TType>> logger;
    
    public LoggerAdapter(ILogger<LoggerAdapter<TType>> logger)
    {
        this.logger = logger;
    }
    
    public void LogInformation(string template, params object[] args)
    {
        logger.LogInformation(template, args);    
    }

    public void LogInformation(LogLevel logLevel, string template, object[] args)
    {
        logger.Log(logLevel, template, args);
    }

    public IDisposable TimedOperation(string template, object[] args)
    {
        return new TimedLogOperation<TType>(this, LogLevel.Information, template, args);
    }
}