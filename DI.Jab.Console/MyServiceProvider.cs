using Jab;

namespace DI.Jab.Console;

[ServiceProvider]
[Transient(typeof(IConsoleWriter), typeof(ConsoleWriter))]
[Transient(typeof(IWeatherService), typeof(WeatherService))]
public partial class MyServiceProvider
{
    
}