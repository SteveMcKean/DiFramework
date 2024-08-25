// See https://aka.ms/new-console-template for more information

using DI.Jab.Console;

var serviceProvider = new MyServiceProvider();
var consoleWriter = serviceProvider.GetService<IConsoleWriter>();

consoleWriter.WriteLine("Hello, World!");

Console.ReadLine();