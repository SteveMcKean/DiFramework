﻿namespace Vax;

public class ServiceProvider 
{
    private readonly Dictionary<Type, Func<object>> transientTypes = new();
    private readonly Dictionary<Type, Lazy<object>> singletonTypes = new();
    
    public T? GetService<T>()
    {
        return (T?)GetService(typeof(T));
        
    }
    
    public object? GetService(Type serviceType)
    {
        var service = singletonTypes.GetValueOrDefault(serviceType);
        if(service is not null)
        {
            return service.Value;
        }
        
        var transientService = transientTypes.GetValueOrDefault(serviceType);
        return transientService?.Invoke();
    }
    
    internal ServiceProvider(ServiceCollection serviceCollection)
    {
        GenerateServices(serviceCollection);
    }
    
    private void GenerateServices(ServiceCollection serviceCollection)
    {
        foreach (var serviceDescriptor in serviceCollection)
        {
            switch (serviceDescriptor.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    if (serviceDescriptor.Implementation is not null)
                    {
                        singletonTypes[serviceDescriptor.ServiceType] =
                            new Lazy<object>(() => serviceDescriptor.Implementation);
                        
                        continue;    
                    }
                    
                    if(serviceDescriptor.ImplementationFactory is not null)
                    {
                        singletonTypes[serviceDescriptor.ServiceType] =
                            new Lazy<object>(() => serviceDescriptor.ImplementationFactory(this));
                        
                        continue;
                    }
                    
                    singletonTypes[serviceDescriptor.ServiceType] =
                        new Lazy<object>(() => Activator.CreateInstance(serviceDescriptor.ImplementationType
                        , GetConstructorParameters(serviceDescriptor))!);
                    
                    continue;
                   
                case ServiceLifetime.Transient:
                    if(serviceDescriptor.ImplementationFactory is not null)
                    {
                        transientTypes[serviceDescriptor.ServiceType] =
                            () => serviceDescriptor.ImplementationFactory!(this);
                        
                        continue;
                    }
                    
                    transientTypes[serviceDescriptor.ServiceType] =
                        () => Activator.CreateInstance(serviceDescriptor.ImplementationType
                        , GetConstructorParameters(serviceDescriptor))!;
                    
                    continue;
            }
        }
    }
    
    private object?[] GetConstructorParameters(ServiceDescriptor descriptor)
    {
        var constructor = descriptor.ImplementationType!.GetConstructors().First();
        var parameters = constructor.GetParameters()
            .Select(x => GetService(x.ParameterType)).ToArray();

        return parameters;
    }
}