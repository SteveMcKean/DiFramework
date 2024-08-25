namespace Consumer.ConsoleApp;

public interface IWeatherService
{
    Task<WeatherResponse> GetWeatherAsync(string city);
}