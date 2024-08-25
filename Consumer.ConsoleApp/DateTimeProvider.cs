namespace Consumer.ConsoleApp;

public class DateTimeProvider: IDateTimeProvider
{
    private readonly ILoggerAdapter<DateTimeProvider> logger;
    public DateTimeProvider(ILoggerAdapter<DateTimeProvider> logger)
    {
        this.logger = logger;
    }
    
    public DateTime Now
    {
        get
        {
            logger.LogInformation("DateTimeProvider.Now was called");
            return DateTime.Now;
        }
    }
}