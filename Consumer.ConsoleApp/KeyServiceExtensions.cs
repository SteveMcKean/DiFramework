using Microsoft.Extensions.DependencyInjection;

namespace Consumer.ConsoleApp;

public static class KeyedServiceExtensions
{
    // Dictionary to store services by key
    private static readonly Dictionary<string, Type> _serviceTypes = new();

    public static IServiceCollection AddKeyedService<TService, TImplementation>(this IServiceCollection services, string key)
        where TService : class
        where TImplementation : class, TService
    {
        // Register the service with the DI container
        services.AddTransient<TImplementation>();
        _serviceTypes[key] = typeof(TImplementation);

        return services;
    }

    public static TService GetKeyedService<TService>(this IServiceProvider serviceProvider, string key)
        where TService : class
    {
        if (_serviceTypes.TryGetValue(key, out var serviceType))
        {
            return serviceProvider.GetService(serviceType) as TService;
        }

        throw new KeyNotFoundException($"Service with key '{key}' not found.");
    }
}