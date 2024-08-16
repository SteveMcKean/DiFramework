namespace Vax;

public class ServiceCollection : List<ServiceDescriptor>
{
    public ServiceCollection AddService(ServiceDescriptor descriptor)
    {
        Add(descriptor);
        return this;
    }
   
    public ServiceCollection AddSingleTon<TService>(Func<ServiceProvider, TService> factory) 
        where TService: class
    {
        var serviceDescriptor = new ServiceDescriptor
            {
                ServiceType = typeof(TService),
                ImplementationType = typeof(TService),
                ImplementationFactory = factory,
                Lifetime = ServiceLifetime.Singleton
            };

        Add(serviceDescriptor);
        return this;
    }

    public ServiceCollection AddSingleton(object implementation)
    {
        var serviceType = implementation.GetType();
        var serviceDescriptor = new ServiceDescriptor
            {
                ServiceType = serviceType,
                ImplementationType = serviceType,
                Implementation = implementation,
                Lifetime = ServiceLifetime.Singleton
            };

        Add(serviceDescriptor);
        return this;
        
    }
    public ServiceCollection AddSingleton<TService>() where TService: class
    {
        return AddServiceDescriptorWithLifeTime<TService, TService>(ServiceLifetime.Singleton);
    }
    
    public ServiceCollection AddSingleton<TService, TImplementation>() where TService: class
        where TImplementation: class, TService
    {
        return AddServiceDescriptorWithLifeTime<TService, TImplementation>(ServiceLifetime.Singleton);
    }

    public ServiceCollection AddTransient<TService>(Func<ServiceProvider, TService> factory) 
        where TService: class
    {
        var serviceDescriptor = new ServiceDescriptor
            {
                ServiceType = typeof(TService),
                ImplementationType = typeof(TService),
                ImplementationFactory = factory,
                Lifetime = ServiceLifetime.Transient
            };

        Add(serviceDescriptor);
        return this;
    }
    
    public ServiceCollection AddTransient<TService, TImplementation>()where TService: class
        where TImplementation: class, TService
    {
        return AddServiceDescriptorWithLifeTime<TService, TImplementation>(ServiceLifetime.Transient);
    }

    public ServiceCollection AddTransient<TService>() where TService: class
    {
        return AddServiceDescriptorWithLifeTime<TService, TService>(ServiceLifetime.Transient);
    }
    
    public ServiceProvider BuildServiceProvider()
    {
        return new ServiceProvider(this);
    }

    private ServiceCollection AddServiceDescriptorWithLifeTime<TService, TImplementation>(
        ServiceLifetime serviceLifetime)
    {
        Add(new ServiceDescriptor
            {
                ServiceType = typeof(TService),
                ImplementationType = typeof(TImplementation),
                Lifetime = serviceLifetime
            });

        return this;
    }
}