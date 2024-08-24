

using Consumer.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();

services.AddLogging(builder =>
    {
        builder.AddConsole();
        builder.AddDebug();
        builder.AddLog4Net("log4net.config");
    });

services.AddTransient(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
services.AddSingleton<IConsoleWriter, ConsoleWriter>();

services.AddKeyedService<IdGenerator, IdGenerator>("IdGenerator");
services.AddKeyedService<IIdGenerator, IdGenerator>("IdGenerator2");

services.AddSingleton(provider => new IdGenerator( provider.GetService<IConsoleWriter>()));
var serviceProvider = services.BuildServiceProvider();


var service = serviceProvider.GetKeyedService<IdGenerator>("IdGenerator");
var service2= serviceProvider.GetKeyedService<IIdGenerator>("IdGenerator2");
//var service3 = serviceProvider.GetService<IIdGenerator>();

Console.WriteLine(service.Id);
Console.WriteLine(service2.Id);
//Console.WriteLine(service3.Id);


service?.PrintId();
service2?.PrintId();
//service3?.PrintId();

Console.ReadLine();
//service?.WriteLine("Hello from DI");