using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Consumer.ConsoleApp;

public class LoggedWeatherService : IWeatherService
{
    private readonly IWeatherService weatherService;
    private readonly ILoggerAdapter<IWeatherService> logger;

    public LoggedWeatherService(IWeatherService weatherService, ILoggerAdapter<IWeatherService> logger)
    {
        this.weatherService = weatherService;
        this.logger = logger;
    }

    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        using var _ = logger.TimedOperation("Weather retrieval for {0}, ", [city]); 
        return await weatherService.GetWeatherAsync(city);
    }
}