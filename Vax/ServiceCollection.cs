namespace Vax;

public class ServiceCollection : List<ServiceDescriptor>
{
    public ServiceCollection AddSingleton<TService, TImplementation>()
    {
        return AddServiceDescriptorWithLifeTime<TService, TImplementation>(ServiceLifetime.Singleton);
    }

    public ServiceCollection AddTransient<TService, TImplementation>()
    {
        return AddServiceDescriptorWithLifeTime<TService, TImplementation>(ServiceLifetime.Transient);
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