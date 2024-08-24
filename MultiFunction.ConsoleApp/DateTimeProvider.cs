namespace MultiFunction.ConsoleApp;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now { get; }
    public DateTime UtcNow { get; }
}