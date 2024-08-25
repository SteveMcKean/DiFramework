

using Consumer.ConsoleApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

services.AddLogging(builder =>
    {
        builder.ClearProviders();
        
        builder.AddConsole();
        builder.AddDebug();
        builder.AddLog4Net("log4net.config");
        builder.AddSerilog(Log.Logger);

    });

services.AddTransient(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
services.AddSingleton<IConsoleWriter, ConsoleWriter>();

services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
services.AddKeyedService<IdGenerator, IdGenerator>("IdGenerator");
services.AddKeyedService<IIdGenerator, IdGenerator>("IdGenerator2");

services.AddSingleton(provider => new IdGenerator( provider.GetService<IConsoleWriter>()));

// services.AddTransient<OpenWeatherService>();
// services.AddTransient<IWeatherService>(provider => new LoggedWeatherService(provider.GetRequiredService<OpenWeatherService>(),
//     provider.GetRequiredService<ILoggerAdapter<IWeatherService>>()));

// scrutor
services.AddTransient<IWeatherService, OpenWeatherService>();
services.Decorate<IWeatherService, LoggedWeatherService>();

var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetKeyedService<IdGenerator>("IdGenerator");
var service2= serviceProvider.GetKeyedService<IIdGenerator>("IdGenerator2");

Console.WriteLine(service.Id);
Console.WriteLine(service2.Id);

service?.PrintId();
service2?.PrintId();

var dateTimeProvider = serviceProvider.GetService<IDateTimeProvider>();
Console.WriteLine(dateTimeProvider.Now);

Console.ReadLine();
