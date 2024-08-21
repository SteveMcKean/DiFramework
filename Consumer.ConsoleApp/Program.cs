

using Consumer.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
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