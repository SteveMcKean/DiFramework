namespace Consumer.ConsoleApp;

public interface IIdGenerator
{
    Guid Id { get; }
    void PrintId();
}