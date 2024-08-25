namespace Consumer.ConsoleApp;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}