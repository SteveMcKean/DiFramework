namespace Consumer.ConsoleApp;

public class OpenWeatherService : IWeatherService
{
    private readonly ILoggerAdapter<OpenWeatherService> logger;
    public OpenWeatherService(ILoggerAdapter<OpenWeatherService> logger)
    {
        this.logger = logger;
    }
    
    public Task<WeatherResponse> GetWeatherAsync(string city)
    {
        throw new NotImplementedException();
    }
}