// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using MultiFunction.ConsoleApp;
using MultiFunction.ConsoleApp.Handlers;

var services = new ServiceCollection();

services.AddSingleton<IConsoleWriter, ConsoleWriter>();
services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
services.AddSingleton<HandlerOrchestrator>();


services.AddCommandHandlers(typeof(Program).Assembly);

var serviceProvider = services.BuildServiceProvider();