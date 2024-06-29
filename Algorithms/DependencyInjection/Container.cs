namespace Algorithms.DependencyInjection;

public class Container
{
    private readonly Dictionary<Type, Func<object?>> _registrations = new();

    public void Register<TService, TImplementation>() where TImplementation : TService
    {
        _registrations[typeof(TService)] = () => Resolve(typeof(TImplementation));
    }

    public void RegisterSingleton<TService>(TService? instance)
    {
        _registrations[typeof(TService)] = () => instance;
    }

    public TService? Resolve<TService>()
    {
        return (TService)Resolve(typeof(TService))!;
    }

    private object? Resolve(Type serviceType)
    {
        if (_registrations.TryGetValue(serviceType, out var creator))
            return creator();

        var constructor = serviceType.GetConstructors().First();
        var parameterTypes = constructor.GetParameters().Select(p => p.ParameterType);
        var parameters = parameterTypes.Select(Resolve).ToArray();

        return Activator.CreateInstance(serviceType, parameters);
    }
}