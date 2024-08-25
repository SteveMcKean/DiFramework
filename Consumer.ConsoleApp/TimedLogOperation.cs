using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Consumer.ConsoleApp;

public class TimedLogOperation<T>: IDisposable
{
    private readonly ILoggerAdapter<T> logger;
    private readonly LogLevel logLevel;
    private readonly string message;
    private readonly object?[] args;
    private readonly Stopwatch stopwatch;

    public TimedLogOperation(ILoggerAdapter<T> logger, LogLevel logLevel, string message, object[] args)
    {
        this.logger = logger;
        this.logLevel = logLevel;
        this.message = message;
        this.args = args;
        
        stopwatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        stopwatch.Stop();
        logger.LogInformation(logLevel, $"{message} completed in {stopwatch.ElapsedMilliseconds}ms", args);
    }
}