

using Consumer.ConsoleApp;
using Vax;

var services = new ServiceCollection();

// services.AddSingleton<IConsoleWriter, ConsoleWriter>();

services.AddSingleton<ConsoleWriter>();

services.AddSingleTon(provider => new IdGenerator( provider.GetService<ConsoleWriter>()));
var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetService<IdGenerator>();
// var service2= serviceProvider.GetService<IIdGenerator>();
// var service3 = serviceProvider.GetService<IIdGenerator>();

//Console.WriteLine(service.Id);
// Console.WriteLine(service2.Id);
// Console.WriteLine(service3.Id);


service?.PrintId();
// service2?.PrintId();
// service3?.PrintId();

Console.ReadLine();
//service?.WriteLine("Hello from DI");